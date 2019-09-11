using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class Unit<U> : ScriptableObject where U : Unit<U>
    {
        [SerializeField]
        protected List <Item> items = new List<Item>();

        [SerializeField]
        protected List<StatusEffect> statusEffects = new List<StatusEffect>();

        protected Dictionary<Type, OnTriggeredEffect> effectDict = new Dictionary<Type, OnTriggeredEffect>();
        protected Dictionary<Type, int> baseStats = new Dictionary<Type, int>();
        protected delegate void OnTriggeredEffect(U unit);

        void OnEnable ()
        {
            foreach(Item item in items)
            {
                Subscribe(item);
            }
            Reset();
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

        public virtual void Reset ()
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

            if (statusEffects.Contains(instance)) // Todo: Proper check
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
                effectDelegate.Invoke((U)this);
            }
        }

        protected void Subscribe (Item item)
        {
            foreach (TriggeredEffectBase effect in item.TriggeredEffects)
            {
                OnTriggeredEffect effectDelegate;
                var triggerType = effect.trigger.GetType();
                if (effectDict.TryGetValue(triggerType, out effectDelegate))
                {
                    effectDelegate += ((IResolve<U>)effect).Resolve;
                } else
                {
                    effectDict[triggerType] = ((IResolve<U>)effect).Resolve;
                }
            }
        }

        protected void Unsubscribe (Item item)
        {
            foreach(TriggeredEffectBase effect in item.TriggeredEffects)
            {
                effectDict[effect.trigger.GetType()] -= ((IResolve<U>)effect).Resolve;
            }
        }
    }
}
