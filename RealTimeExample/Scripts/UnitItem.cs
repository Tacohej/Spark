using UnityEngine;
using Spark;

public abstract class UnitItem : ScriptableObject, IEquippable<Unit>
{
    public abstract void Equip(Unit unit);
    public abstract void Unequip(Unit unit);
}