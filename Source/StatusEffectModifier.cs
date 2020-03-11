using UnityEngine;
using System.Collections.Generic;

namespace Spark
{
    public enum DurationModifier
    {
        Stack,
        Reset,
        None
    }

    public abstract class StatusEffectModifier : ScriptableObject
    {
        public string statusEffectName;
        public float duration;
        public bool debuff;
        
        public DurationModifier durationModifier = DurationModifier.Stack;
        public int maxStackAmount;
        public int stackAmount;
        public bool stackable;
        public bool loseAllStacksOnExpire;

        public abstract void OnApply (StatusEffect statusEffect, Unit unit);
        public abstract void OnExpire (StatusEffect statusEffect, Unit unit);
        public abstract void OnTick (StatusEffect statusEffect, Unit unit);
    }
}