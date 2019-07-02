using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/TriggeredEffects/GainPowerOnAttack")]
public class GainPowerBuffOnAttack : TriggeredEffect
{
    [SerializeField]
    private StatusEffect powerBuff;

    public override string GetDescription()
    {
        return "Gain power boost";
    }

    public override void Resolve(Unit unit)
    {
        Debug.Log("Test");
        unit.AddStatusEffect(powerBuff);
    }
}
