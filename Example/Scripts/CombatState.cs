public struct CombatState
{
    public Character self;
}

public struct CombatStateWithTarget
{
    public Character self;
    public Character target;
}

public struct CombatStateWithTargets
{
    public Character self;
    public Character[] targets;
}