using System.Collections;
using System.Collections.Generic;
using Spark;


public class BootsOfSpeed : Item, IEquippable<Player>
{
    private StatModifier moveSpeedModifier;

    public BootsOfSpeed ()
    {
        itemName = "Boots Of Speed";
        moveSpeedModifier = new StatModifier();
        moveSpeedModifier.statModType = StatModType.Flat;
        moveSpeedModifier.value = 55;
    }

    public void OnEquip(Player player)
    {
        player.MoveSpeed.AddModifier(moveSpeedModifier);
    }

    public void OnUnequip(Player player)
    {
        player.MoveSpeed.RemoveModifier(moveSpeedModifier);
    }
}