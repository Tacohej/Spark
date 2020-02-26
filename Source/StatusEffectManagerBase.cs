using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

namespace Spark
{
    public abstract class StatusEffectManagerBase: MonoBehaviour
    {
        protected List<StatusEffect> statusEffects = new List<StatusEffect>();

        public StatusEffect Apply (StatusEffect statusEffect)
        {
            statusEffect.RefreshDuration();
            statusEffects.Add(statusEffect);
            return statusEffect;
        }

        public void Remove (StatusEffect statusEffect)
        {
            statusEffects.Remove(statusEffect);
        }

    }

    public class TurnBasedStatusEffectManager : StatusEffectManagerBase
    {
        public void Tick ()
        {
            foreach(var statusEffect in statusEffects)
            {
                var effect = statusEffect as TurnBasedStatusEffect;
                if (effect)
                {
                    effect.Tick();
                }
            }
        }
    }

    public class RealTimeStatusEffectManager : StatusEffectManagerBase
    {
        public void Tick (float dt)
        {
            foreach(var statusEffect in statusEffects)
            {
                var effect = statusEffect as RealTimeStatusEffect;
                effect.Tick(dt);
            }
        }
    }
}
