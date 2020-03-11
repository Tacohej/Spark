using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/Reactions/ApplyStatusEffectToSelf")]
public class ApplyStatusEffectToSelf : Reaction
{
    [SerializeField]
    private StatusEffectModifier modifier = default;

    public override void Resolve(Unit unit)
    {
        var targetManager = unit.GetComponent<StatusEffectManager>();
        targetManager.ApplyModifier(modifier);
    }
}