using UnityEngine;

namespace Spark
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Resolve(Unit unit);
    }
}