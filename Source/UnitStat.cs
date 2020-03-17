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
    public class StatModifier
    {
        public StatModType statModType;
        
        [SerializeField]
        private int initialValue;

        [System.NonSerialized]
        private int bonusValue = 0;

        public void AddValue (int value)
        {
            bonusValue += value;
        }

        public int Value { get {return initialValue + bonusValue; }}
    }

    [Serializable]
    public class UnitStat
    {
        [SerializeField]
        private int baseValue = 0;
        private List<StatModifier> statModifiers = new List<StatModifier>();
        private bool dirty = true;
        private int totalValue;

        public int Value {
            get {
                if (dirty)
                {
                    int flatValue = 0;
                    int multiplierValue = 0;
                    foreach (StatModifier statModifier in statModifiers)
                    {
                        if (statModifier.statModType == StatModType.Flat)
                        {
                            flatValue += statModifier.Value;
                        }
                        if (statModifier.statModType == StatModType.Multiplier)
                        {
                            multiplierValue += statModifier.Value;
                        }
                    }
                    totalValue = (int)((baseValue + flatValue) * (1 + multiplierValue * 0.001f));
                    dirty = false;
                }
                return totalValue;
            }
        }

        public void AddModifier (StatModifier statModifier)
        {
            statModifiers.Add(statModifier);
            dirty = true;
        }

        public void UpdateModifier (StatModifier statModifier, int value)
        {
            statModifier.AddValue(value);
            dirty = true;
        }

        public void OnChange (Action<int> action)
        {
            // TODO
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
