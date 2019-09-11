using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/MyUnit")]
public class SparkUnit : Unit<SparkUnit>
{
    public int baseHealth = 100;
    public int baseHealthRegen = 0;
    public int baseMovementSpeed = 7;

    public override void OnEnable ()
    {
        base.OnEnable();
        this.SetBaseStat<Health>(baseHealth);
        this.SetBaseStat<HealthRegen>(baseHealthRegen);
        this.SetBaseStat<MovementSpeed>(baseMovementSpeed);
    }
}