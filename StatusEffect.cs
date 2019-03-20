using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [CreateAssetMenu(menuName="ItemEffectSystem/StatusEffect")]
    public class StatusEffect : ScriptableObject
    {
        [SerializeField]
        private List<Stat> stats = new List<Stat>();

        public string statusEffectName;
        public bool hasDuration = false;
        public int maxStackAmount = 1;
        public int maxDuration = 1;

        [System.NonSerialized]
        public int stackAmount;
        [System.NonSerialized]
        public int duration;

        public int GetTotalOfStat<T> () where T : Stat
        {
            var total = 0;
            foreach(Stat stat in stats)
            {
                if (stat is T)
                {
                    total += stat.value * stackAmount;
                }
            }
            return total;
        }
    }
}
