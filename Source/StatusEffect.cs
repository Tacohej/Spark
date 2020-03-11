using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public class StatusEffect
    {
        private StatusEffectModifier modifier;
        private int stackAmount;
        private float duration;
        private string statusEffectName;

        public int StackAmount {get;}
        public StatusEffectModifier Modifier {get;}
        public float Duration {get;}

        public StatusEffect (StatusEffectModifier modifier)
        {
            this.modifier = modifier;
        }

        public void AddStacks (int amount)
        {
            stackAmount = Mathf.Clamp(stackAmount + amount, 1, modifier.maxStackAmount);
        }

        public void AddDuration (float duration)
        {
            this.duration += duration;
        }

        public void ResetDuration (float duration)
        {
            this.duration = duration;
        }

        public void Update (float time)
        {
            duration -= time;
        }

        public bool IsExpired ()
        {
            return duration <= 0;
        }

        public void OnApply (Unit unit)
        {
            this.modifier.OnApply(this, unit);
        }

        public void OnExpire (Unit unit)
        {
            this.modifier.OnExpire(this, unit);
        }

        public void OnTick (Unit unit)
        {
            this.modifier.OnTick(this, unit);
        }
    }
}
