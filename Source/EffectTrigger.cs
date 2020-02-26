using System;
using System.Collections.Generic;

namespace Spark
{
    public class TriggeredEffectModifier
    {
        public string key;
        public Action action;
    }

    public class EffectTrigger
    {
        public delegate void OnEffectTriggered(Unit unit);
        public event OnEffectTriggered triggeredEffect;

        public void TriggerEffect (Unit unit)
        {
            triggeredEffect?.Invoke(unit);
        }

        public void RegisterTriggeredEffect (OnEffectTriggered effect)
        {
            triggeredEffect += effect;
        }

        public void UnregisterTriggeredEffect (OnEffectTriggered effect)
        {
            triggeredEffect -= effect;
        }
    }
}