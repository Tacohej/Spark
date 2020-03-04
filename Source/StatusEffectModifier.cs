using UnityEngine;
using System;

namespace Spark
{
    // [Serializable]
    // public class StatusEffectModifier
    // {
    //     public bool stackAddAmount;
    //     public int maxStacks;
    //     public bool refreshDurationOnStacks;
        
        
    //     public string statusEffectName;
    //     public float duration;
    // }


    public abstract class StatusEffectModifier : ScriptableObject
    {
        public string statusEffectName;
        public float tickInterval; // ?
        public bool isDebuff;

        public abstract void OnApply (Unit unit, StatusEffect statusEffect);
        public abstract void OnExpire (Unit unit, StatusEffect statusEffect);
        public abstract void OnTick (Unit unit, StatusEffect statusEffect);
    }
}