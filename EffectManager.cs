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

        protected bool ContainsStatusEffect (string name) // maybe use something else than name
        {
            for (int i = 0; i < statusEffects.Count; i++)
            {
                if (statusEffects[i].name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetStatTotal<T> () where T : StatType
        {
            var value = 0;
            for (int i = 0; i < items.Count; i++)
            {
                value += items[i].GetTotalOfStat<T>();
            }

            for (int i = 0; i < statusEffects.Count; i++)
            {
                value += statusEffects[i].GetTotalOfStat<T>();
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
            List<Item> items = GetItemsWithTrigger<T>();
            for (int i = 0; i < items.Count; i++)
            {
                List<TriggeredEffect> effects = items[i].GetEffectsWithTrigger<T>();
                for (int j = 0; j < effects.Count; j++)
                {
                    TriggeredEffect effect = effects[j];
                    effects[j].reaction.Resolve(effects[j]);
                }
            }
        }
    }
}
