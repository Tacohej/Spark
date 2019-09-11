using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [CreateAssetMenu(menuName="Spark/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField]
        protected List<Stat> stats = new List<Stat>();
        [SerializeField]
        protected List<TriggeredEffectBase> effects = new List<TriggeredEffectBase>();

        [NonSerialized]
        private string description = string.Empty;

        public List<TriggeredEffectBase> TriggeredEffects
        {
            get { return effects; }
        }

        protected List<StatType> GetAllStatTypes ()
        {
            List<StatType> statTypes = new List<StatType>();

            foreach(Stat stat in stats)
            {
                if (!statTypes.Contains(stat.statType))
                {
                    statTypes.Add(stat.statType);
                }
            }

            return statTypes;
        }

        private (int, int) GetStatTotal (StatType statType)
        {
            var flatTotal = 0;
            var percentTotal = 0;
            for (int i = 0; i < stats.Count; i++)
            {
                Stat stat = stats[i];
                if (stat.statType == statType)
                {
                    if (stat.statValueType == StatValueType.Flat)
                    {
                        flatTotal += stat.value;
                    } else
                    {
                        percentTotal += stat.value;
                    }
                }
            }
            return (flatTotal, percentTotal);
        }

        public (int, int) GetStatTotal<T> () where T : StatType
        {
            var flatTotal = 0;
            var percentTotal = 0;
            for (int i = 0; i < stats.Count; i++)
            {
                Stat stat = stats[i];
                if (stat.statType is T)
                {
                    if (stat.statValueType == StatValueType.Flat)
                    {
                        flatTotal += stat.value;
                    } else
                    {
                        percentTotal += stat.value;
                    }
                }
            }

            return (flatTotal, percentTotal);
        }

        public virtual string GetDescription ()
        {
            string text = String.Empty;
            List<StatType> statTypes = GetAllStatTypes();

            foreach(StatType statType in statTypes)
            {
                (int flatValue, int percentValue) = GetStatTotal(statType);

                if (flatValue != 0)
                {
                    text += $"+ {flatValue} {statType.GetStatTypeName()}. ";
                }

                if (percentValue != 0)
                {
                    text += $"{percentValue}% {statType.GetStatTypeName()}.";
                }
            }

            foreach(TriggeredEffectBase effect in effects)
            {
                text += $"{effect.trigger.name}: {effect.GetDescription()}. ";
            }

            description = text;
            return text;
        }
    }
}
