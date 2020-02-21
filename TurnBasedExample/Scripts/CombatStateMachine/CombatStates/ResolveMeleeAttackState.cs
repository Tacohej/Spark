using UnityEngine;

[CreateAssetMenu(menuName="Game/CombatState/ResolveMeleeAttackState")]

public class ResolveMeleeAttackState : CombatState
{
    public CombatState ResolutionState;

    public override CombatState Execute(Dungeon dungeon)
    {
        var attacker = dungeon.GetNextAttackingUnit();
        var defender = dungeon.GetNextDefendingUnit();

        // TODO: add randomness, crit and evation
        var rawDamage = attacker.Strength.Value;

        attacker.OnAttackTrigger.TriggerEffect(new EffectDataWithTarget(attacker, defender));
        Debug.Log($"{attacker} attacks {defender} for {rawDamage}");
        var damageTaken = defender.ReciveDamage(rawDamage, Unit.DamageType.Physical);
        Debug.Log($"{defender} took {damageTaken} damage. {defender.Health} left");
        defender.OnAttackedTrigger.TriggerEffect(new EffectDataWithTarget(attacker, defender));

        return ResolutionState;

    }
}