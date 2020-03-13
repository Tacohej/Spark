using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [Serializable]
    public enum StatModType
    {
        Flat,
        Multiplier
    }

    [Serializable]
    public struct StatModifierValue
    {
        public StatModType statModType;
        public int value;
    }

    [Serializable]
    public struct StatModifier
    {
        public string statKey;
        public StatModifierValue statModifierValue;
    }

    [Serializable]
    public class UnitStat
    {
        private List<StatModifierValue> statModifiers = new List<StatModifierValue>();
        private bool dirty = true;
        private int baseValue;

        [SerializeField] // TEMP
        private int totalValue;

        public int Value {
            get {
                if (dirty)
                {
                    int flatValue = 0;
                    int multiplierValue = 1;
                    foreach (StatModifierValue statModifier in statModifiers)
                    {
                        if (statModifier.statModType == StatModType.Flat)
                        {
                            flatValue += statModifier.value;
                        }
                        if (statModifier.statModType == StatModType.Multiplier)
                        {
                            multiplierValue += statModifier.value;
                        }
                    }
                    totalValue = (baseValue + flatValue) * multiplierValue;
                    dirty = false;
                }
                return totalValue;
            }
        }

        public UnitStat (int baseValue = 0)
        {
            this.baseValue = baseValue;
        }

        public void AddModifier (StatModifierValue statModifier)
        {
            if (statModifiers.Contains(statModifier))
            {
                Debug.Log("TODO: FIX ME");
            }
            statModifiers.Add(statModifier);
            dirty = true;
        }

        public void RemoveModifier (StatModifierValue statModifier)
        {
            if (statModifiers.Remove(statModifier))
            {
                dirty = true;
            }
        }
    }
}
