using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public abstract class Item : ScriptableObject
    {
        public abstract void OnEquip(Unit unit);
        public abstract void OnUnequip(Unit unit);
    }
}
