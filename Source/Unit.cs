using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public class Unit : MonoBehaviour
    {
        public List<Item> items = new List<Item>();
        public Dictionary<string, UnitStat> unitStats = new Dictionary<string, UnitStat>();
        public Dictionary<string, EffectTrigger> effectTriggers = new Dictionary<string, EffectTrigger>();

        public void EquipItem(Item item)
        {
            item.OnEquip(this);
            items.Add(item);
        }

        public void AddTriggeredEffect (string key, Action reaction)
        {
            EffectTrigger effectTrigger;
            if (effectTriggers.TryGetValue(key, out effectTrigger))
            {
                effectTrigger.RegisterTriggeredEffect(reaction);
            }
                else
            {
                effectTriggers[key] = new EffectTrigger();
                effectTriggers[key].RegisterTriggeredEffect(reaction);
            }
        }

        public void AddModifier (StatModifier modifier)
        {
            UnitStat unitStat;
            var key = modifier.statKey;

            if (unitStats.TryGetValue(key, out unitStat))
            {
                unitStat.AddModifier(modifier);
            }
                else
            {
                unitStats[key] = new UnitStat();
                unitStats[key].AddModifier(modifier);
            }
        }

        // public void EditModifier (StatModifier modifier, int value)
        // {
        //     UnitStat unitStat;
        //     if (unitStats.TryGetValue(modifier.statKey, out unitStat))
        //     {
        //         modifier.statModifierValue.value = value;
        //     }
        //         else
        //     {
        //         Debug.LogWarning("No modifier registered with key: " + modifier.statKey);
        //     }
        // }

        public void TriggerEffect (string trigger)
        {
            EffectTrigger effectTrigger;
            if (effectTriggers.TryGetValue(trigger, out effectTrigger))
            {
                effectTrigger.TriggerEffect();
            }
                else
            {
                Debug.LogWarning("No effects registered with trigger : " + trigger);
            }
        }

        public int GetStat (string key)
        {
            UnitStat unitStat;
            if (unitStats.TryGetValue(key, out unitStat))
            {
                return unitStat.Value;
            }

            Debug.LogWarning("No stat found with key: " + key);
            return 0;
        }
    }
}
