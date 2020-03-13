using Spark;
using UnityEngine;

public class StatModifierStatusEffect : StatusEffectModifier
{
    [SerializeField] StatModifier statModifier = default;

    public override void OnApply(StatusEffect statusEffect, Unit unit)
    {
        var newValue = statModifier.statModifierValue.value * statusEffect.StackAmount;
        // unit.EditModifier(statModifier, newValue);
    }

    public override void OnExpire(StatusEffect statusEffect, Unit unit)
    {
        return;
    }

    public override void OnTick(StatusEffect statusEffect, Unit unit)
    {
        return;
    }
}