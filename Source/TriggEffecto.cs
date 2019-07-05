using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class TriggEffecto<T> : TriggeredEffect, ITriggeredEffect<T>
    {
        public abstract override string GetDescription();
        public abstract void Resolve(T unit);
    }
}
