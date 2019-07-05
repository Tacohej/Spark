using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/TriggeredEffects/GainPowerOnAttack")]
public class GainPowerBuffOnAttack : TriggEffecto<Character>
{
    [SerializeField]
    private StatusEffect powerBuff;

    public override string GetDescription()
    {
        return "Gain power buff on attack";
    }

    public override void Resolve(Character unit)
    {
        unit.SayHello();
    }
}
