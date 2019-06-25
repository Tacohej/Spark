using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [CreateAssetMenu(menuName="Spark/Unit")]
    public class Unit : ScriptableObject
    {
        protected delegate void OnTrigger(Unit unit); // temp
        [SerializeField]
        protected List <Item> items = new List<Item>();
        protected List<StatusEffect> statusEffects = new List<StatusEffect>();
        protected Dictionary<System.Type, OnTrigger> effectDict = new Dictionary<System.Type, OnTrigger>();

        public void SetItems (List<Item> items)
        {
            this.items = items;
        }

        public void Reset ()
        {
            statusEffects = new List<StatusEffect>();
        }

        public void RemoveStatusEffect (StatusEffect effect) 
        {
            statusEffects.Remove(effect);
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

        public void AddStatusEffect (StatusEffect statusEffect)
        {
            var instance = Instantiate(statusEffect);

            if (statusEffects.Contains(instance))
            {
                if (instance.maxStackAmount > 1 && instance.stackAmount < instance.maxStackAmount)
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

        public int GetStatTotal<T> (int baseValue) where T : StatType
        {
            var flatValue = 0;
            var percentValue = 0;
            for (int i = 0; i < items.Count; i++)
            {
                flatValue += items[i].GetTotalStatFlat<T>();
                percentValue += items[i].GetTotalStatPercent<T>();
            }

            for (int i = 0; i < statusEffects.Count; i++)
            {
                flatValue += statusEffects[i].GetTotalStatFlat<T>();
                percentValue += statusEffects[i].GetTotalStatPercent<T>();
            }

            return Mathf.RoundToInt((baseValue + flatValue) * (1 + percentValue * 0.01f));
        }

        public void TriggerEffects<T> () where T : Trigger
        {
            OnTrigger effectDelegate;
            if (effectDict.TryGetValue(typeof(T), out effectDelegate))
            {
                effectDelegate.Invoke(this);
            }
        }

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

        protected void Subscribe (Item item)
        {
            foreach (TriggeredEffect effect in item.TriggeredEffects)
            {
                OnTrigger effectDelegate;
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
