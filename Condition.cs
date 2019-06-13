using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class Condition : ScriptableObject
    {
        public abstract bool IsMet<T>(T sparkUnit) where T : SparkUnit;
    }
}
