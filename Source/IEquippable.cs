using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public interface IEquippable<T>
    {
        void OnEquip (T unit);
        void OnUnequip (T unit);
    }
}

