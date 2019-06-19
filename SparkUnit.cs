using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public class SparkUnit : ScriptableObject
    {
        [SerializeField]
        protected List <Item> items = new List<Item>();

        [SerializeField]
        protected List<StatusEffect> statusEffects = new List<StatusEffect>();

        protected TriggeredEffect triggeredEffect;
        protected Item triggeredItem;
        protected StatusEffect triggeredStatusEffect;

        public TriggeredEffect TriggeredEffect
        {
            get { return triggeredEffect; }
        }

        public Item TriggeredItem
        {
            get { return triggeredItem; }
        }

        public StatusEffect StatusEffect
        {
            get { return triggeredStatusEffect; }
        }

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

        public virtual void Reset ()
        {
            statusEffects = new List<StatusEffect>();
        }

        public List<Item> GetItemsWithTrigger<T>()
        {
            return items.FindAll(item => item.HasEffectWithTrigger<T>());
        }

        public List<StatusEffect> GetStatusEffectsWithTrigger<T>()
        {
            return statusEffects.FindAll(statusEffect => statusEffect.HasEffectWithTrigger<T>());
        }

        public virtual void TriggerEffects<T> () where T : Trigger
        {

            List<StatusEffect> triggeredStatusEffects = GetStatusEffectsWithTrigger<T>();

            for (int i = 0; i < triggeredStatusEffects.Count; i++)
            {
                triggeredStatusEffect = triggeredStatusEffects[i];
                List<TriggeredEffect> effects = triggeredStatusEffect.GetEffectsWithTrigger<T>();
                for (int j = 0; j < effects.Count; j++)
                {
                    triggeredEffect = effects[j];
                    triggeredEffect.reaction.Resolve(this);
                }
            }

            triggeredStatusEffect = null;

            List<Item> items = GetItemsWithTrigger<T>();
            for (int i = 0; i < items.Count; i++)
            {
                triggeredItem = items[i];
                List<TriggeredEffect> effects = triggeredItem.GetEffectsWithTrigger<T>();
                for (int j = 0; j < effects.Count; j++)
                {
                    triggeredEffect = effects[j];
                    if (triggeredEffect.ConditionsAreMet(this))
                    {
                        triggeredEffect.reaction.Resolve(this);
                    }
                }
            }

            triggeredItem = null;

        }
    }
}
