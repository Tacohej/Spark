using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class SparkUnit : ScriptableObject
    {
        [SerializeField]
        protected List <Item> items = new List<Item>();

        [System.NonSerialized]
        protected List<StatusEffect> statusEffects = new List<StatusEffect>();

        public void SetItems (List<Item> items)
        {
            this.items = items;
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

            // TODO: Precision
            return Mathf.RoundToInt((baseValue + flatValue) * (1 + percentValue * 0.01f));
        }

        public void AddStatusEffect (StatusEffect statusEffect)
        {
            if (statusEffects.Contains(statusEffect))
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
                var item = items[i];
                List<TriggeredEffect> effects = item.GetEffectsWithTrigger<T>();
                for (int j = 0; j < effects.Count; j++)
                {
                    TriggeredEffect effect = effects[j];
                    if (effect.ConditionsAreMet(this))
                    {
                        effects[j].reaction.Resolve(this);
                    }
                }
            }
        }
    }
}
