using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class Reaction : ScriptableObject
    {
        public abstract void Resolve(SparkUnit sparkUnit);

        public abstract string GetDescription ();
    }
}
