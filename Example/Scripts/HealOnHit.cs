using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/TriggeredEffects/HealOnHit")]
public class HealOnHit
{
    [SerializeField]
    private int healAmount;
    [SerializeField]
    private Player player;
}
