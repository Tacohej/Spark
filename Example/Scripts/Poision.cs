using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public class Poision : CharacterStatusEffect
{ 

    public override void OnApply(Character unit)
    {
        // unit.statusEffectManager.Remove 
        // unit.statusEffectManager.AddStacks()
    }

    public override void OnExpire(Character unit)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTick(Character unit)
    {
        throw new System.NotImplementedException();
    }
}
