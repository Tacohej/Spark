using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

namespace Spark
{
    public abstract class TriggeredEffect<T> : TriggeredEffectBase, IResolve<T>
    {
        public abstract override string GetDescription();
        public abstract void Resolve(T unit);
    }
}
