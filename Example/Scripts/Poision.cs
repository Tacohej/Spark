using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poision : CharacterStatusEffect
{
    public float duration;

    public override void OnApply(Character unit)
    {
        return;
    }

    public override void OnExpire(Character unit)
    {
        return;
    }

    public override void Tick(float time)
    {
        throw new System.NotImplementedException();
    }
}
