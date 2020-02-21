using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public class Poision : CharacterStatusEffect
{ 

    public override void OnApply(Unit unit)
    {
        // unit.statusEffectManager.Remove 
        // unit.statusEffectManager.AddStacks()
    }

    public override void OnExpire(Unit unit)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTick(Unit unit)
    {
        throw new System.NotImplementedException();
    }
}
