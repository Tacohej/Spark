using System;

namespace Spark
{
    [Serializable]
    public class TriggeredEffectModifier
    {
        public string trigger;
        public Reaction<IEffectArgs> reaction;
    }

    public class EffectTrigger
    {
        public delegate void OnEffectTriggered(Unit unit, IEffectArgs args);
        public static event OnEffectTriggered triggeredEffect;

        public void TriggerEffect (Unit unit, IEffectArgs args)
        {
            triggeredEffect?.Invoke(unit, args);
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