using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [CreateAssetMenu(menuName="Spark/Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public bool equippable = true;

        public List<StatModifier> statModifiers = new List<StatModifier>();
        public List<TriggeredEffectModifier> triggeredEffectModifiers = new List<TriggeredEffectModifier>();

        public void Equip(Unit unit)
        {
            foreach (StatModifier mod in statModifiers)
            {
                unit.AddModifier(mod.statKey, mod.statModifierValue);
            }

            foreach (TriggeredEffectModifier mod in triggeredEffectModifiers)
            {
                unit.AddTriggeredEffect(mod.trigger, mod.action);
            }
        }

        public void Unequip(Unit unit)
        {
            foreach (StatModifier mod in statModifiers)
            {
                // Remove
            }

            foreach (TriggeredEffectModifier mod in triggeredEffectModifiers)
            {
                // Remove
            }
        }
    }
}
