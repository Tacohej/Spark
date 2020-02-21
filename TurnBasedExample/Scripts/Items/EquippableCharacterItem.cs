using Spark;

public abstract class EquippableCharacterItem : Item, IEquippable<Unit>
{
    public abstract void OnEquip(Unit t);
    public abstract void OnUnequip(Unit t);
}