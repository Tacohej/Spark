
using System.Collections.Generic;

namespace Spark
{
    public class TurnBasedManager<T> : StatusEffectManager<T, TurnbasedStatusEffect<T>>
    {
        public TurnBasedManager (T unit) : base(unit) {}

        public override void Update()
        {
            List<string> removeList = new List<string>();

            foreach (KeyValuePair<string, TurnbasedStatusEffect<T>> effect in statusEffects)
            {
                var statusEffect = effect.Value;

                statusEffect.Tick(unit);
                if (statusEffect.UpdateDuration())
                {
                    removeList.Add(effect.Key);
                    statusEffect.Expire(unit);
                }
            }

            foreach (string key in removeList)
            {
                statusEffects.Remove(key);
            }
        }
    }
}