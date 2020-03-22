using System;
using UnityEngine;

namespace Spark
{
    public class RealTimeStatusEffect<T> : StatusEffect<T>
    {
        private float duration = 5;
        private float tickInterval = 1;
        private float startingDuration;

        private float timeGone = 0;
        private float tickTimer = 0;

        public float StackDuration { get { return  duration - timeGone; } }
        public float StartDuration { get { return startingDuration; } }

        public RealTimeStatusEffect (string name) : base(name)
        {
            startingDuration = duration;
        }

        public RealTimeStatusEffect<T> OnApply (Action<T> callback)
        {
            applyCallback += callback;
            return this;
        }

        public RealTimeStatusEffect<T> OnTick (Action<T> callback)
        {
            tickCallback += callback;
            return this;
        }

        public RealTimeStatusEffect<T> OnExpire (Action<T> callback)
        {
            expireCallback += callback;
            return this;
        }

        public RealTimeStatusEffect<T> OnStackChange (Action<T, int> callback)
        {
            stackAmountChangeCallback += callback;
            return this;
        }

        public RealTimeStatusEffect<T> Duration (float duration)
        {
            this.duration = duration;
            startingDuration = this.duration;
            return this;
        }

        public override void Reset ()
        {
            base.Reset();
            timeGone = 0;
            tickTimer = 0;
        }

        public override void AddStack (T unit)
        {
            base.AddStack(unit);
            timeGone = 0;
        }

        public bool UpdateTick (float dt)
        {
            tickTimer += dt;

            if (tickTimer >= tickInterval)
            {
                tickTimer = tickTimer % tickInterval;
                return true;
            }

            return false;
        }

        public bool UpdateDuration (float dt, T unit)
        {
            timeGone += dt;

            if (timeGone >= duration)
            {
                timeGone = timeGone % duration;
                RemoveStack(unit);
            }

            return stackAmount <= 0;
        }
    }
}