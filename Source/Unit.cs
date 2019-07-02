using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [CreateAssetMenu(menuName="Spark/Unit")]
    public class Unit : ScriptableObject
    {
        [SerializeField]
        protected List <Item> items = new List<Item>();

        protected List<StatusEffect> statusEffects = new List<StatusEffect>();
        protected Dictionary<Type, OnTriggeredEffect> effectDict = new Dictionary<Type, OnTriggeredEffect>();
        protected Dictionary<Type, int> baseStats = new Dictionary<Type, int>();
        protected delegate void OnTriggeredEffect(Unit unit);

        void OnEnable ()
        {
            foreach(Item item in items)
            {
                Subscribe(item);
            }
        }

        void OnDisable ()
        {
            foreach(Item item in items)
            {
                Unsubscribe(item);
            }
        }

        public void EquipItem (Item item)
        {
            items.Add(item);
            Subscribe(item);
        }

        public void UnequipItem (Item item)
        {
            items.Remove(item);
            Unsubscribe(item);
        }

        public void EquipItems (List<Item> items)
        {
            foreach(Item item in items)
            {
                Subscribe(item);
            }
            this.items = items;
        }

        public void UnequipAllItems ()
        {
            foreach(Item item in items)
            {
                Unsubscribe(item);
            }
        }

        public void Reset ()
        {
            statusEffects = new List<StatusEffect>();
        }

        public void RemoveStatusEffect (StatusEffect effect) 
        {
            statusEffects.Remove(effect);
        }

        public void AddStatusEffect (StatusEffect statusEffect)
        {
            var instance = Instantiate(statusEffect);

            if (statusEffects.Contains(instance))
            {
                if (instance.stackAmount < instance.maxStackAmount)
                {
                    instance.stackAmount++;
                }
            } else
            {
                instance.stackAmount = 1;
                statusEffects.Add(instance);
            }
            instance.duration = instance.maxDuration;
        }

        public void SetBaseStat<T> (int value)
        {
            baseStats[typeof(T)] = value;
        }

        public int GetStatTotal<T> () where T : StatType
        {
            var flatValue = 0;
            var percentValue = 0;
            var baseValue = 0;

            baseStats.TryGetValue(typeof(T), out baseValue);

            for (int i = 0; i < items.Count; i++)
            {
                (int flat, int percent) = items[i].GetStatTotal<T>();
                flatValue += flat;
                percentValue += percent;
            }

            for (int i = 0; i < statusEffects.Count; i++)
            {
                (int flat, int percent) = statusEffects[i].GetStatTotal<T>();
                flatValue += flat;
                percentValue += percent;
            }

            return Mathf.RoundToInt((baseValue + flatValue) * (1 + percentValue * 0.01f));
        }

        public void TriggerEffects<T> () where T : Trigger
        {
            OnTriggeredEffect effectDelegate;
            if (effectDict.TryGetValue(typeof(T), out effectDelegate))
            {
                effectDelegate.Invoke(this);
            }
        }

        protected void Subscribe (Item item)
        {
            foreach (TriggeredEffect effect in item.TriggeredEffects)
            {
                OnTriggeredEffect effectDelegate;
                var triggerType = effect.trigger.GetType();
                if (effectDict.TryGetValue(triggerType, out effectDelegate))
                {
                    effectDelegate += effect.Resolve;
                } else
                {
                    effectDict[triggerType] = effect.Resolve;
                }
            }
        }

        protected void Unsubscribe (Item item)
        {
            foreach(TriggeredEffect effect in item.TriggeredEffects)
            {
                effectDict[effect.trigger.GetType()] -= effect.Resolve;
            }
        }
    }
}
