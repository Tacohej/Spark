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
    public struct StatModifier
    {
        public StatModType statModType;
        public int value;
    }

    [Serializable]
    public class UnitStat
    {
        private List<StatModifier> statModifiers = new List<StatModifier>();
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
                    foreach (StatModifier statModifier in statModifiers)
                    {
                        if (statModifier.statModType == StatModType.Flat)
                            flatValue += statModifier.value;
                        if (statModifier.statModType == StatModType.Multiplier)
                            multiplierValue += statModifier.value;
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

        public void AddModifier (StatModifier statModifier)
        {
            statModifiers.Add(statModifier);
            dirty = true;
        }

        public void RemoveModifier (StatModifier statModifier)
        {
            if (statModifiers.Remove(statModifier))
            {
                dirty = true;
            }
        }
    }
}
