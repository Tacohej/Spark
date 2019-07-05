using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

namespace Spark
{
    public abstract class TriggeredEffect: ScriptableObject
    {
        public Trigger trigger;
        public abstract string GetDescription ();
    }
}
