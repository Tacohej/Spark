using System.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [CreateAssetMenu(menuName="Spark/Item")]
    public class SparkItem : ScriptableObject
    {
        [SerializeField]
        private List<Stat> stats = new List<Stat>();
        [SerializeField]
        private List<TriggeredEffect> effects = new List<TriggeredEffect>();

        [NonSerialized]
        private string description = string.Empty;

        protected List<StatType> GetAllStatTypes ()
        {
            List<StatType> statTypes = new List<StatType>();

            foreach(Stat stat in stats)
            {
                if (!statTypes.Contains(stat.type))
                {
                    statTypes.Add(stat.type);
                }
            }

            return statTypes;
        }

        public List<TriggeredEffect> GetEffectsWithTrigger<T> () where T : Trigger
        {
            return effects.FindAll(effect => effect.trigger is T);
        }

        public int GetTotalStatFlat (StatType statType)
        {
            var total = 0;
            for (int i = 0; i < stats.Count; i++)
            {
                Stat stat = stats[i];
                if (stat.type == statType)
                {
                    total += stat.flatValue;
                }
            }
            return total;
        }

        public int GetTotalStatFlat<T> () where T : StatType
        {
            var total = 0;
            for (int i = 0; i < stats.Count; i++)
            {
                Stat stat = stats[i];
                if (stat.type is T)
                {
                    total += stat.flatValue;
                }
            }
            return total;
        }

        public int GetTotalStatPercent (StatType statType)
        {
            var total = 0;
            for (int i = 0; i < stats.Count; i++)
            {
                Stat stat = stats[i];
                if (stat.type == statType)
                {
                    total += stat.percentValue;
                }
            }

            return total;
        }

        public int GetTotalStatPercent<T> () where T : StatType
        {
            // TODO: combine with GetTotalFlat
            var total = 0;
            for (int i = 0; i < stats.Count; i++)
            {
                Stat stat = stats[i];
                if (stat.type is T)
                {
                    total += stat.percentValue;
                }
            }

            return total;
        }

        public bool HasEffectWithTrigger<T>()
        {
            for (int i = 0; i < effects.Count; i++)
            {
                if (effects[i].trigger is T)
                {
                    return true;
                }
            }
            return false;
        }

        public virtual string GetDescription ()
        {
            if (description != "")
            {
                return description;
            }

            string text = "";
            List<StatType> statTypes = GetAllStatTypes();

            foreach(StatType statType in statTypes)
            {
                var flatValue = GetTotalStatFlat(statType);
                var percentValue = GetTotalStatPercent(statType);

                if (flatValue != 0)
                {
                    text += "+ " + flatValue + " " + statType.statName + ". ";
                }

                if (percentValue != 0)
                {
                    text += "" + percentValue + "% " + statType.statName + ". ";
                }
            }

            foreach(TriggeredEffect effect in effects)
            {
                text += effect.trigger.triggerName + ": " + effect.reaction.GetDescription() + ". ";
            }

            description = text;
            return text;
        }
    }
}
