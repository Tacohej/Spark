using Spark;

public abstract class CharacterStatusEffect : TurnBasedStatusEffect, IApplicable<Unit>
{
    public abstract void OnApply(Unit unit);
    public abstract void OnExpire(Unit unit);
    public abstract void OnTick(Unit unit);
}