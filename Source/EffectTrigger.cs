using System;
using System.Collections.Generic;

namespace Spark
{
    public class EffectTrigger<T>
    {
        public delegate void OnTriggeredEffect(T arg);
        public event OnTriggeredEffect triggeredEffect;

        public void TriggerEffect (T arg)
        {
            triggeredEffect.Invoke(arg);
        }

        public void RegisterTriggeredEffect (OnTriggeredEffect effect)
        {
            triggeredEffect += effect;
        }

        public void UnregisterTriggeredEffect (OnTriggeredEffect effect)
        {
            triggeredEffect -= effect;
        }
    }
}