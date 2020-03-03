using UnityEngine;

namespace Spark
{
    public abstract class Reaction : ScriptableObject
    {
        public abstract void Resolve(Unit unit);
    }
}