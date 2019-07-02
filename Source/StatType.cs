using System.Collections;
using UnityEngine;

namespace Spark
{
    public abstract class StatType : ScriptableObject
    {
        public virtual string GetStatTypeName ()
        {
            return this.name;
        }
    }
}