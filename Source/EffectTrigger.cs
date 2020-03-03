using System;

namespace Spark
{

    [Serializable]
    public class TriggeredEffectModifier
    {
        public string trigger;
        public Reaction reaction;
    }

    public class EffectTrigger
    {
        public delegate void OnEffectTriggered(Unit unit);
        public static event OnEffectTriggered triggeredEffect;

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