using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/Reactions/ReciveDamage")]
public class ReciveDamage : Reaction
{
    [SerializeField]
    private int damageAmount = default;

    public override void Resolve(Unit unit)
    {
        var player = unit.GetComponent<Player>();
        player.ReciveDamage(damageAmount);
    }
}
