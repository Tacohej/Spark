using UnityEngine;
using System.Collections.Generic;

namespace Spark
{
    public class RealTimeManager<T> : StatusEffectManager<T, RealTimeStatusEffect<T>>
    {
        public RealTimeManager (T unit) : base(unit) {}

        public override void Update ()
        {
            List<string> removeList = new List<string>();

            foreach (KeyValuePair<string, RealTimeStatusEffect<T>> effect in statusEffects)
            {
                var statusEffect = effect.Value;

                if (statusEffect.UpdateDuration(Time.deltaTime, unit))
                {
                    removeList.Add(effect.Key);
                    statusEffect.Expire(unit);
                } 
                else if (statusEffect.UpdateTick(Time.deltaTime))
                {
                    statusEffect.Tick(unit);
                }
            }

            foreach (string key in removeList)
            {
                statusEffects.Remove(key);
            }
        }
    }
}