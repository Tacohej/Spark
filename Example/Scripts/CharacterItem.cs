using Spark;

public abstract class EquippableCharacterItem : Item, IEquippable<Character>
{
    public abstract void OnEquip(Character t);
    public abstract void OnUnequip(Character t);
}