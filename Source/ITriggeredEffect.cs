using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public interface ITriggeredEffect<T>
    {
        void Resolve(T unit);
    }
}
