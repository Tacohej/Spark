using System;

namespace Spark
{
    public abstract class StatusEffect<T>
    {
        protected event Action<T> applyCallback;
        protected event Action<T> tickCallback;
        protected event Action<T> expireCallback;
        protected event Action<T, int> stackAmountChangeCallback;

        protected string _name;

        protected int stackAmount = 1;
        protected int maxStackAmount = 5;

        public string Name { get { return _name; } }
        public int StackAmount { get { return stackAmount; } }

        public StatusEffect (string name)
        {
            _name = name;
        }

        public StatusEffect<T> MaxStackAmount (int amount)
        {
            this.maxStackAmount = amount;
            return this; 
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

        public virtual void Reset ()
        {
            stackAmount = 1;
        }

        public virtual void AddStack (T unit)
        {
            if (stackAmount < maxStackAmount)
            {
                stackAmount += 1;
                stackAmountChangeCallback?.Invoke(unit, stackAmount);
            }
        }

        public virtual void RemoveStack (T unit)
        {
            stackAmount -= 1;
            if (stackAmount > 0)
            {
                stackAmountChangeCallback?.Invoke(unit, stackAmount);
            }
        }
    }
}