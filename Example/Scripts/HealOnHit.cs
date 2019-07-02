using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/TriggeredEffects/HealOnHit")]
public class HealOnHit : TriggeredEffect
{
    [SerializeField]
    private int healAmount;
    [SerializeField]
    private Player player;

    public override string GetDescription()
    {
        return $"Healed { healAmount }";
    }

    public override void Resolve(Unit unit)
    {
        player.Heal();
        Debug.Log($"Heal for {healAmount}");
    }
}
