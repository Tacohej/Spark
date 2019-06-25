using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [CreateAssetMenu(menuName="Spark/StatusEffect")]
    public class StatusEffect : ScriptableObject
    {
        [SerializeField]
        protected List<Stat> stats = new List<Stat>();

        [SerializeField]
        protected List<TriggeredEffect> effects = new List<TriggeredEffect>();

        public string statusEffectName;
        public bool hasDuration = false;
        public int maxStackAmount = 1;
        public int maxDuration = 1;
        public bool doStackStats = true;

        public int stackAmount;
        [System.NonSerialized]
        public int duration;

        public int GetTotalStatFlat<T> () where T : StatType
        {
            var total = 0;
            for (int i = 0; i < stats.Count; i++)
            {
                Stat stat = stats[i];
                if (stat.type is T)
                {
                    total += doStackStats
                        ? stat.flatValue * stackAmount
                        : stat.flatValue;
                }
            }
            return total;
        }

        public int GetTotalStatPercent<T> () where T : StatType
        {
            var total = 0;
            for (int i = 0; i < stats.Count; i++)
            {
                Stat stat = stats[i];
                if (stat.type is T)
                {
                    total += doStackStats
                        ? stat.percentValue * stackAmount
                        : stat.percentValue;
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

        public List<TriggeredEffect> GetEffectsWithTrigger<T> () where T : Trigger
        {
            return effects.FindAll(effect => effect.trigger is T);
        }
    }
}
