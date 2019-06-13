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
        private string description = "";

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

            var text = "";

            List<StatType> statTypes = GetAllStatTypes();

            foreach(StatType statType in statTypes)
            {
                MethodInfo flatMethod = typeof(SparkItem).GetMethod("GetTotalStatFlat");
                MethodInfo percentMethod = typeof(SparkItem).GetMethod("GetTotalStatPercent");
                MethodInfo flatGeneric = flatMethod.MakeGenericMethod(statType.GetType());
                MethodInfo percentGeneric = percentMethod.MakeGenericMethod(statType.GetType());
                var flatValue = (int)flatGeneric.Invoke(this, null);
                var percentValue = (int)percentGeneric.Invoke(this, null);

                if (flatValue != 0)
                {
                    text += "+ " + flatValue + " " + statType.GetType() + ". ";
                }

                if (percentValue != 0)
                {
                    text += "" + percentValue + "% " + statType.GetType() + ". ";
                }
            }

            foreach(TriggeredEffect effect in effects)
            {
                text += effect.trigger.GetType().ToString().ToUpper() + ": " + effect.reaction.GetDescription() + ". ";
            }

            description = text;
            return text;

        }
    }
}
