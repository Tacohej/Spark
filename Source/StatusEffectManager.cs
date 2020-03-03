using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

namespace Spark
{
    public class StatusEffectManager: MonoBehaviour
    {
        protected List<StatusEffect> statusEffects = new List<StatusEffect>();

        public void ApplyModifier (StatusEffectModifier modifier)
        {
            
        }

        // public StatusEffect Apply (StatusEffect statusEffect)
        // {
        //     statusEffect.RefreshDuration();
        //     statusEffects.Add(statusEffect);
        //     return statusEffect;
        // }

        // public void Remove (StatusEffect statusEffect)
        // {
        //     statusEffects.Remove(statusEffect);
        // }

    }
}
