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
        protected List<TriggeredEffectBase> effects = new List<TriggeredEffectBase>();

        public string statusEffectName;
        public bool scaleStatsWithStacks = true;
        public int maxStackAmount = 1;
        public int stackAmount = 1;

        public (int, int) GetStatTotal<T> () where T : StatType
        {
            var flatTotal = 0;
            var percentTotal = 0;

            foreach(Stat stat in stats)
            {
                if (stat.statType is T)
                {
                    var value = scaleStatsWithStacks ? stat.value * stackAmount : stat.value;
                    if (stat.statValueType == StatValueType.Flat)
                    {
                        flatTotal += value;
                    } else
                    {
                        percentTotal += value;
                    }
                }
            }

            return (flatTotal, percentTotal);
        }
    }
}
