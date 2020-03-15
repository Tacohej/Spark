using System;

namespace Spark
{
    public class EffectTrigger
    {
        public event Action triggeredEffect;

        public void TriggerEffect ()
        {
            triggeredEffect?.Invoke();
        }

        public void RegisterTriggeredEffect (Action effect)
        {
            triggeredEffect += effect;
        }

        public void UnregisterTriggeredEffect (Action effect)
        {
            triggeredEffect -= effect;
        }
    }
}