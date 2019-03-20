using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class EffectManager : ScriptableObject
    {
        [SerializeField]
        protected List <Item> items = new List<Item>();

        [System.NonSerialized]
        protected List<StatusEffect> statusEffects = new List<StatusEffect>();

        protected bool ContainsStatusEffect (string name)
        {
            foreach(StatusEffect statusEffect in statusEffects)
            {
                if (statusEffect.name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetStatTotal<T> () where T : Stat {
            var value = 0;
            foreach(Item item in items)
            {
                value += item.GetTotalOfStat<T>();
            }
            foreach(StatusEffect statusEffect in statusEffects)
            {
                value += statusEffect.GetTotalOfStat<T>();
            }
            return value;
        }

        public void AddStatusEffect (StatusEffect statusEffect)
        {
            if (ContainsStatusEffect(statusEffect.name))
            {
                if (statusEffect.maxStackAmount > 1 && statusEffect.stackAmount < statusEffect.maxStackAmount)
                {
                    statusEffect.stackAmount++;
                }
            } else
            {
                statusEffect.stackAmount = 1;
                statusEffects.Add(statusEffect);
            }
            statusEffect.duration = statusEffect.maxDuration;
        }

        public void RemoveStatusEffect (string name) 
        {
            for (int i = 0; i < statusEffects.Count; i++) 
            {
                var statusEffect = statusEffects[i];
                if (statusEffect.name == name) 
                {
                    statusEffects.RemoveAt(i);
                }
            }
        }

        public List<Item> GetItemsWithTrigger<T>()
        {
            return items.FindAll(item => item.HasEffectWithTrigger<T>());
        }

        public void TriggerEffects<T> () where T : Trigger
        {
            foreach(Item item in GetItemsWithTrigger<T>())
            {
                foreach(TriggeredEffect effect in item.GetEffectsWithTrigger<T>())
                {
                    effect.reaction.Resolve(effect);
                }
            }
        }
    }
}
