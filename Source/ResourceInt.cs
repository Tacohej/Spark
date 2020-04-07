using UnityEngine;

namespace Spark
{
    [System.Serializable]
    public class ResourceInt
    {
        private FormulaInt formula;
        [SerializeField]
        private int current = 0;

        public ResourceInt (FormulaInt formula, bool startAtMax = true)
        {
            this.formula = formula;
            if (startAtMax)
            {
                current = formula.Value;
                
                Debug.Log(current);
            }
        }

        public int Value
        {
            get { return Mathf.Min(formula.Value, current); }
            set { current = value; }
        }

        public float Fraction
        {
            get { return (float)Value / (float)Max; }
        }

        public int Max
        {
            get { return formula.Value; }
        }
    }
}
