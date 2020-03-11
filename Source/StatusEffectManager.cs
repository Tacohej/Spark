﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

namespace Spark
{
    [RequireComponent(typeof(Unit))]
    public class StatusEffectManager: MonoBehaviour
    {
        private Dictionary<string, StatusEffect> statusEffects = new Dictionary<string, StatusEffect>();
        private Unit unit;

        void Start ()
        {
            unit = GetComponent<Unit>();
        }

        public void ApplyModifier (StatusEffectModifier modifier)
        {
            StatusEffect statusEffect;
            if (statusEffects.TryGetValue(modifier.statusEffectName, out statusEffect))
            {
                if (modifier.stackable)
                {
                    statusEffect.AddStacks(modifier.stackAmount);
                }

                if (modifier.durationModifier == DurationModifier.Stack)
                {
                    statusEffect.AddDuration(modifier.duration);
                }

                else if (modifier.durationModifier == DurationModifier.Reset)
                {
                    statusEffect.ResetDuration(modifier.duration);
                }
            }
            else
            {
                statusEffect = new StatusEffect(modifier);
                statusEffects[modifier.statusEffectName] = statusEffect;
            }

            statusEffect.OnApply(unit);
        }

        public void Update ()
        {
            foreach (KeyValuePair<string, StatusEffect> se in statusEffects)
            {
                var statusEffect = se.Value;
                statusEffect.Update(Time.deltaTime);

                if (statusEffect.IsExpired())
                {
                    // TODO: handle stacks
                    // TODO: remove status effect when no stacks
                    statusEffect.OnExpire(unit);
                }
            }
        }

        public void Tick (float dt)
        {

        }

    }
}