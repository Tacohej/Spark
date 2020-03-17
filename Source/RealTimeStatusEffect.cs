using System;
using UnityEngine;

namespace Spark
{
    public class RealTimeStatusEffect<T>
    {
        private event Action<T> applyCallback;
        private event Action<T> tickCallback;
        private event Action<T> expireCallback;

        private string _name;
        private float duration = 5;
        private float tickInterval = 1;
        private float startingDuration;

        private int stackAmount = 1;
        private float timeGone = 0;
        private float tickTimer = 0;

        public string Name { get { return _name; } }
        public int StackAmount { get { return stackAmount; } }
        public float StackDuration { get { return  duration - timeGone; } }
        public float StartDuration { get { return startingDuration; } }

        public RealTimeStatusEffect (string name)
        {
            startingDuration = duration;
            _name = name;
        }

        public void Reset ()
        {
            stackAmount = 1;
            timeGone = 0;
            tickTimer = 0;
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

        public RealTimeStatusEffect<T> WithDuration (float duration)
        {
            this.duration = duration;
            startingDuration = this.duration;
            return this;
        }

        public void AddStack ()
        {
            stackAmount += 1;
            timeGone = 0;
        }

        public void RemoveStack ()
        {
            stackAmount -= 1;
        }

        public void Apply (T unit)
        {
            applyCallback?.Invoke(unit);
        }

        public void Tick (T unit)
        {
            tickCallback?.Invoke(unit);
        }

        public void Expire (T unit)
        {
            expireCallback?.Invoke(unit);
        }

        public void ResetTimeGone ()
        {
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

        public bool UpdateDuration (float dt)
        {
            timeGone += dt;

            if (timeGone >= duration)
            {
                timeGone = timeGone % duration;
                RemoveStack();
            }

            return stackAmount <= 0;
        }

    }
}