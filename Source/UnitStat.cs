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
        
        public int initialValue;

        [System.NonSerialized]
        private int multiplier = 1;

        public Action OnChange;

        public int Multiplier
        {
            set { OnChange?.Invoke(); multiplier = value; }
            get { return multiplier; }
        }

        public int Value {
            get { return initialValue * multiplier; }
        }
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

        private void SetDirty ()
        {
            dirty = true;
        }

        public void AddModifier (StatModifier statModifier)
        {
            if (!statModifiers.Contains(statModifier))
            {
                statModifiers.Add(statModifier);
                statModifier.OnChange += SetDirty;
                dirty = true;
            }
        }

        public void OnChange (Action<int> action)
        {
            // TODO
        }

        public void RemoveModifier (StatModifier statModifier)
        {
            if (statModifiers.Remove(statModifier))
            {
                statModifier.OnChange -= SetDirty;
                dirty = true;
            }
        }
    }
}
