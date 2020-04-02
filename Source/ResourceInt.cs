using UnityEngine;

namespace Spark
{
    public class ResourceInt
    {
        private FormulaInt formula;
        private int current = 0;
        private int min;

        public ResourceInt (FormulaInt formula, int minValue = 0)
        {
            this.formula = formula;
            this.min = minValue;
        }

        public int Value
        {
            get { return (int)formula.Value + current; }
            set { current = Mathf.Clamp(value, Min, Max); }
        }

        public int Max
        {
            get { return formula.Value; }
        }

        public int Min
        {
            get { return min; }
        }
    }
}
