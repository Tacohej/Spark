using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class TriggeredEffect : ScriptableObject
    {
        public Trigger trigger;
        public abstract void Resolve (Unit unit);
        public abstract string GetDescription ();
    }
}
