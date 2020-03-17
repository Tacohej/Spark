using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public interface IEquippable<T>
    {
        void Equip(T unit);
        void Unequip(T unit);
    }
}
