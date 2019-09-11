using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(fileName="SpeedUpOnAttack", menuName="Game/TriggeredEffects/SpeedUpOnAttack")]
public class SpeedUpOnAttack : TriggeredEffect<SparkUnit>
{
    public StatusEffect speedBuff;

    public override string GetDescription()
    {
        throw new System.NotImplementedException();
    }

    public override void Resolve(SparkUnit unit)
    {
        Debug.Log("OnAttack");
        unit.AddStatusEffect(speedBuff);
    }
}
