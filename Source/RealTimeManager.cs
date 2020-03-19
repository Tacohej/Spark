using UnityEngine;
using System.Collections.Generic;


namespace Spark
{
    public class RealTimeManager<T>
    {
        private T unit;
        public readonly Dictionary<string, RealTimeStatusEffect<T>> statusEffects = new Dictionary<string, RealTimeStatusEffect<T>>();

        public RealTimeManager (T unit)
        {
            this.unit = unit;
        }

        public void ApplyStatusEffect(RealTimeStatusEffect<T> statusEffect)
        {
            RealTimeStatusEffect<T> currentStatusEffect;
            if (statusEffects.TryGetValue(statusEffect.Name, out currentStatusEffect))
            {
                currentStatusEffect.AddStack(unit);
            }
            else
            {
                statusEffect.Reset();
                statusEffect.Apply(unit);
                statusEffects[statusEffect.Name] = statusEffect;
            }
            
        }

        public void UpdateStatusEffects ()
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