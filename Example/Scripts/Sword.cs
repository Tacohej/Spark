using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/Item/Sword")]
public class Sword : CharacterItem
{
    [SerializeField]
    private StatModifier strengthModifier;

    [SerializeField]
    private int onKillHealAmount = 5;

    void OnKill (CombatStateWithTarget cs) 
    {
        cs.self.Heal(onKillHealAmount);
    }

    public override void Equip(Character character)
    {
        character.Strength.AddModifier(strengthModifier);
        character.OnKillTrigger.RegisterTriggeredEffect(OnKill);
    }

    public override void Unequip(Character character)
    {
        character.Strength.RemoveModifier(strengthModifier);
        character.OnKillTrigger.UnregisterTriggeredEffect(OnKill);
    }
}
