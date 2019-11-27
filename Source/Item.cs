using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class Item<T> : ScriptableObject
    {
        public abstract void Equip (T unit);
        public abstract void Unequip (T unit);
    }
}
