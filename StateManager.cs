using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class StateManager : ScriptableObject
    {
        [System.NonSerialized]
        public SparkItem item;
        [System.NonSerialized]
        public TriggeredEffect effect;
    }
}
