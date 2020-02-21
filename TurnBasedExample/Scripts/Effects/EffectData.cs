public struct EffectData
{
    public EffectData(Unit caster)
    {
        this.caster = caster;
    }

    public Unit caster;
}

public struct EffectDataWithTarget
{
    public EffectDataWithTarget(Unit caster, Unit target)
    {
        this.caster = caster;
        this.target = target;
    }

    public Unit caster;
    public Unit target;
}

public struct EffectDataWithTargets
{
    public Unit caster;
    public Unit[] targets;
}