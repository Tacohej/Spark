using UnityEngine;
using System.Collections.Generic;


namespace Spark
{
    public class RealTimeUnit : Unit
    {
        public readonly Dictionary<string, RealTimeStatusEffect> statusEffects = new Dictionary<string, RealTimeStatusEffect>();

        public void ApplyStatusEffect(RealTimeStatusEffect statusEffect)
        {
            RealTimeStatusEffect currentStatusEffect;
            if (statusEffects.TryGetValue(statusEffect.Name, out currentStatusEffect))
            {
                currentStatusEffect.AddStack();
                statusEffect.Apply(this);
            }
            else
            {
                statusEffect.Reset();
                statusEffect.Apply(this);
                statusEffects[statusEffect.Name] = statusEffect;
            }
            
        }

        public void UpdateStatusEffects ()
        {
            List<string> removeList = new List<string>();

            foreach (KeyValuePair<string, RealTimeStatusEffect> effect in statusEffects)
            {
                var statusEffect = effect.Value;

                if (statusEffect.UpdateDuration(Time.deltaTime))
                {
                    removeList.Add(effect.Key);
                    statusEffect.Expire(this);
                } 
                else if (statusEffect.UpdateTick(Time.deltaTime))
                {
                    statusEffect.Tick(this);
                }
            }

            foreach (string key in removeList)
            {
                statusEffects.Remove(key);
            }
        }
    }
}