using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [CreateAssetMenu(menuName="Spark/TurnBasedManager")]
    public class TurnBasedManager : EffectManager
    {
        public void Tick () {
            foreach(StatusEffect statusEffect in statusEffects)
            {
                if (statusEffect.hasDuration)
                {
                    statusEffect.duration--;
                    if (statusEffect.duration <= 0)
                    {
                        RemoveStatusEffect(statusEffect.name);
                    }
                }
            }
        }
    }
}
