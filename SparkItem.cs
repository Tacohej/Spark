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

        public List<TriggeredEffect> GetEffectsWithTrigger<T> () where T : Trigger
        {
            return effects.FindAll(effect => effect.trigger is T);
        }

        public int GetTotalOfStat<T> () where T : StatType
        {
            var total = 0;
            for (int i = 0; i < stats.Count; i++)
            {
                Stat stat = stats[i];
                if (stat.type is T)
                {
                    total += stat.value;
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
    }
}
