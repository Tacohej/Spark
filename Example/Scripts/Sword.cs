using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/Item/Sword")]
public class Sword : EquippableCharacterItem
{
    [SerializeField]
    private StatModifier strengthModifier;

    [SerializeField]
    private CharacterStatusEffect poision;

    [SerializeField]
    private int onKillHealAmount = 5;

    void OnKill (CombatStateWithTarget cs) 
    {
        cs.self.Heal(onKillHealAmount);
    }

    void OnHit (CombatStateWithTarget combatState)
    {
        // combatState.target.AddStatusEffect(poision);
    }

    public override void OnEquip(Character character)
    {
        character.Strength.AddModifier(strengthModifier);
        character.OnKillTrigger.RegisterTriggeredEffect(OnKill);
    }

    public override void OnUnequip(Character character)
    {
        character.Strength.RemoveModifier(strengthModifier);
        character.OnKillTrigger.UnregisterTriggeredEffect(OnKill);
    }
}
