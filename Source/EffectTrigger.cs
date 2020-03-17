using System;
using UnityEngine;

namespace Spark
{

    public class TriggeredEffect
    {
        public event Action effect;

        public void Trigger ()
        {
            effect?.Invoke();
        }

        public Action RegisterEffect (Action effect)
        {
            this.effect += effect;
            return effect;
        }

        public void UnregisterEffect (Action effect)
        {
            this.effect -= effect;
        }

    }

    public class TriggeredEffect<T>
    {
        public event Action<T> effect;

        public void Trigger (T arg)
        {
            effect?.Invoke(arg);
        }

        public Action<T> RegisterEffect (Action<T> effect)
        {
            this.effect += effect;
            return effect;
        }

        public void UnregisterEffect (Action<T> effect)
        {
            this.effect -= effect;
        }
    }
}