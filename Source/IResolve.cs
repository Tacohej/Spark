using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public interface IResolve<T>
    {
        void Resolve(T unit);
    }
}
