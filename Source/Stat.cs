using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    public enum StatValueType
    {
        Flat,
        Percent
    }

    [System.Serializable]
    public class Stat
    {
        public int value;
        public StatValueType statValueType;
        public StatType statType;
    }
}