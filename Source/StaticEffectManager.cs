using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public abstract class StatusEffectManagerBase
{
    protected List<StatusEffect> statusEffects = new List<StatusEffect>();
}

public class TurnBasedStatusEffectManager : StatusEffectManagerBase
{
    public void Tick ()
    {
        
    }
}

public class RealTimeStatusEffectManager : StatusEffectManagerBase
{
    public void Tick (float time)
    {
        
    }
}


// public class StaticEffectModifier
// {

// }

// public interface IRealTimeDurable
// {
//     void Tick(float time);
// }

// public interface ITurnBasedDurable
// {

// }

// public abstract class CharacterStatusEffect : StatusEffect<Character>, IRealTimeDurable
// {
//     public abstract void Tick(float time);
// }

// public abstract class StatusEffectManager<T>
// {
//     public List<T> statusEffects = new List<T>();

//     public void Add (T modifier)
//     {
//         // modifier.
//     }

// }
