using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public interface IConsumable<T>
    {
        void OnUse (T unit);
    }
}

