using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/Actions/ReciveDamage")]
public class ReciveDamage : Reaction<EffectArgs>
{
    [SerializeField]
    private int damageAmount;

    public override void Resolve(Unit unit, EffectArgs args)
    {
        var player = unit.GetComponent<Player>();
        player.ReciveDamage(damageAmount);
    }
}
