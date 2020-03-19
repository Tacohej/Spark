using System;
using UnityEngine;

namespace Spark
{
    public class RealTimeStatusEffect<T>
    {
        private event Action<T> applyCallback;
        private event Action<T> tickCallback;
        private event Action<T> expireCallback;
        private event Action<T, int> stackAmountChangeCallback;

        private string _name;
        private float duration = 5;
        private float tickInterval = 1;
        private float startingDuration;

        private int stackAmount = 1;
        private float timeGone = 0;
        private float tickTimer = 0;
        private int maxStackAmount = 5;

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

        public RealTimeStatusEffect<T> OnStackAmountChange (Action<T, int> callback)
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

        public RealTimeStatusEffect<T> MaxStackAmount (int amount)
        {
            this.maxStackAmount = amount;
            return this; 
        }

        public void AddStack (T unit)
        {
            if (stackAmount < maxStackAmount)
            {
                stackAmount += 1;
                stackAmountChangeCallback?.Invoke(unit, stackAmount);
            }
            timeGone = 0; // temp hard coded
        }

        public void RemoveStack (T unit)
        {
            stackAmount -= 1;
            if (stackAmount > 0)
            {
                stackAmountChangeCallback?.Invoke(unit, stackAmount);
            }
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