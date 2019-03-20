using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [CreateAssetMenu(menuName="ItemEffectSystem/Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public string description;

        // move to own class
        public int cost;
        public Sprite thumbnail;

        [SerializeField]
        private List<TriggeredEffect> effects = new List<TriggeredEffect>();
        [SerializeField]
        private List<Stat> stats = new List<Stat>();

        public List<TriggeredEffect> GetEffectsWithTrigger<T> () where T : Trigger
        {
            return effects.FindAll(effect => effect.trigger is T);
        }

        public int GetTotalOfStat<T> () where T : Stat
        {
            var total = 0;
            foreach(Stat stat in stats)
            {
                if (stat is T)
                {
                    total += stat.value;
                }
            }
            return total;
        }

        public bool HasEffectWithTrigger<T>()
        {
            foreach(TriggeredEffect effect in effects)
            {
                if (effect.trigger is T)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
