using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class Reaction : ScriptableObject
    {
        public abstract void Resolve<T>(T sparkUnit) where T: SparkUnit;

        public abstract string GetDescription ();
    }
}
