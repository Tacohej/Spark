using Spark;

public abstract class CharacterStatusEffect : TurnBasedStatusEffect, IApplicable<Character>
{
    public abstract void OnApply(Character unit);
    public abstract void OnExpire(Character unit);
    public abstract void OnTick(Character unit);
}