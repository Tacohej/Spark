using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/StatusEffectModifiers/StackableStrengthBuff")]
public class StackableStrengthBuff : StatusEffectModifier
{
    public override void OnApply(StatusEffect statusEffect, Unit unit)
    {
        Debug.Log(statusEffect.StackAmount);
        Debug.Log(statusEffect.Duration);
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
