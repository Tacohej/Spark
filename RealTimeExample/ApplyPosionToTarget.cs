using UnityEngine;
using Spark;

public class ApplyPoisonToTarget : Reaction
{
    [SerializeField]
    private StatusEffectModifier statusEffectModifier;

    public override void Resolve(Unit unit)
    {
        // if (args.target)
        // {
        //     args.target
        //         .GetComponent<StatusEffectManager>()
        //         .ApplyModifier(statusEffectModifier);
        // }
    }
}