using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/TriggeredEffects/GainPowerOnAttack")]
public class GainPowerBuffOnAttack : TriggeredEffect<SparkUnit>
{
    [SerializeField]
    private StatusEffect powerBuff;

    public override string GetDescription()
    {
        return "Gain power buff on attack";
    }

    public override void Resolve(SparkUnit unit)
    {
        unit.SayHello();
    }
}
