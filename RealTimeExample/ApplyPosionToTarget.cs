using UnityEngine;
using Spark;

public class ApplyPoisonToTarget : Reaction<EffectArgs>
{
    [SerializeField]
    private StatusEffectModifier statusEffectModifier;

    public override void Resolve(Unit unit, EffectArgs args)
    {
        if (args.target)
        {
            args.target
                .GetComponent<StatusEffectManager>()
                .ApplyModifier(statusEffectModifier);
        }
    }
}