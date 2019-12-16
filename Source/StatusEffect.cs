using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class StatusEffect : ScriptableObject
    {
        private int stackAmount;
        
        public string statusEffectName;
        public int maxStackAmount;

        public int StackAmount {get;}

        public void AddStacks (int amount)
        {
            stackAmount = Mathf.Clamp(stackAmount + amount, 1, maxStackAmount);
        }

        public abstract void RefreshDuration ();
        public abstract bool HasExpired ();
    }

    public class RealTimeStatusEffect : StatusEffect
    {
        public float maxDurationInSeconds;
        private float durationLeft;

        public override bool HasExpired()
        {
            return durationLeft <= 0;
        }

        public override void RefreshDuration ()
        {
            durationLeft = maxDurationInSeconds;
        }

        public void Tick (float dt)
        {
            durationLeft -= dt;
        }
    }

    public class TurnBasedStatusEffect : StatusEffect
    {
        public int maxDurationInTurns;
        private int turnsLeft;

        public override bool HasExpired()
        {
            return turnsLeft <= 0;
        }

        public override void RefreshDuration ()
        {
            turnsLeft = maxDurationInTurns;
        }

        public void Tick ()
        {
            turnsLeft--;
        }
    }
}
