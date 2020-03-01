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

        void Start ()
        {
            foreach (Item item in items)
            {
                EquipItem(item);
            }
        }

        public bool EquipItem(Item item)
        {
            if (item.equippable)
            {
                item.Equip(this);
            }

            return item.equippable;
        }

        public void AddTriggeredEffect (string key, Reaction<IEffectArgs> modifier)
        {
            EffectTrigger effectTrigger;
            if (effectTriggers.TryGetValue(key, out effectTrigger))
            {
                effectTrigger.RegisterTriggeredEffect(modifier.Resolve);
            }
                else
            {
                effectTriggers[key] = new EffectTrigger();
                effectTriggers[key].RegisterTriggeredEffect(modifier.Resolve);
            }
        }

        public void AddModifier (string key, StatModifierValue statModifier)
        {
            UnitStat unitStat;
            if (unitStats.TryGetValue(key, out unitStat))
            {
                unitStat.AddModifier(statModifier);
            }
                else
            {
                unitStats[key] = new UnitStat();
                unitStats[key].AddModifier(statModifier);
            }
        }

        public void TriggerEffect (string trigger, IEffectArgs args = null)
        {
            EffectTrigger effectTrigger;
            if (effectTriggers.TryGetValue(trigger, out effectTrigger))
            {
                effectTrigger.TriggerEffect(this, args);
            }
                else
            {
                Debug.Log("No effects registered with trigger : " + trigger);
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
