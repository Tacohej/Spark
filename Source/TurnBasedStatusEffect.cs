using System;

namespace Spark
{
    public class TurnbasedStatusEffect<T> : StatusEffect<T>
    {
        private int duration;
        private int startingDuration;

        public TurnbasedStatusEffect  (string name) : base(name)
        {
            startingDuration = duration;
        }

        public TurnbasedStatusEffect<T> OnApply (Action<T> callback)
        {
            applyCallback += callback;
            return this;
        }

        public TurnbasedStatusEffect<T> OnTick (Action<T> callback)
        {
            tickCallback += callback;
            return this;
        }

        public TurnbasedStatusEffect<T> OnExpire (Action<T> callback)
        {
            expireCallback += callback;
            return this;
        }

        public TurnbasedStatusEffect<T> OnStackChange (Action<T, int> callback)
        {
            stackAmountChangeCallback += callback;
            return this;
        }

        public TurnbasedStatusEffect<T> Duration (int duration)
        {
            this.duration = duration;
            startingDuration = this.duration;
            return this;
        }

        public bool UpdateDuration ()
        {
            this.duration -= 1;
            return duration <= 0;
        }
    }
}