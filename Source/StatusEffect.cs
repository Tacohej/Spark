using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class StatusEffect<T> : ScriptableObject
    {
        public abstract void OnGained (T unit);
        public abstract void OnLost (T unit);
    }
}
