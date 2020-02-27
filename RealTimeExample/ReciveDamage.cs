using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/Actions/ReciveDamage")]
public class ReciveDamage : Action
{
    [SerializeField]
    private int damageAmount;

    public override void Resolve(Unit unit)
    {
        var player = unit.GetComponent<Player>();
        player.ReciveDamage(damageAmount);
    }
}
