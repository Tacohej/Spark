using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class Trigger : ScriptableObject
    {
        public virtual string GetTriggerName ()
        {
            return this.name;
        }
    }
}
