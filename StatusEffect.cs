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

        public string statusEffectName;
        public bool hasDuration = false;
        public int maxStackAmount = 1;
        public int maxDuration = 1;

        [System.NonSerialized]
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
                    total += stat.flatValue * stackAmount;
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
                    total += stat.percentValue * stackAmount;
                }
            }
            return total;
        }
    }
}
