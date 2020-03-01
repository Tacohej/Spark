using UnityEngine;

namespace Spark
{
    public abstract class Reaction<T> : ScriptableObject where T : IEffectArgs
    {
        public abstract void Resolve(Unit unit, T args);
    }
}