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
    private int onKillHealAmount = 5;

    [SerializeField]
    private Poision poision;

    void OnKill (EffectDataWithTarget cs)
    {
        cs.caster.Heal(onKillHealAmount);
    }

    void OnHit (EffectDataWithTarget data)
    {
        data.target.statusEffectManager.Apply(poision);
    }

    public override void OnEquip(Unit character)
    {
        character.Strength.AddModifier(strengthModifier);
        character.OnKillTrigger.RegisterTriggeredEffect(OnKill);
    }

    public override void OnUnequip(Unit character)
    {
        character.Strength.RemoveModifier(strengthModifier);
        character.OnKillTrigger.UnregisterTriggeredEffect(OnKill);
    }
}
