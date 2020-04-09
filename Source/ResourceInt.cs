using UnityEngine;

namespace Spark
{
    [System.Serializable]
    public class ResourceInt
    {
        private Formula<int> formula;
        [SerializeField]
        private int current = 0;

        public ResourceInt (Formula<int> formula, bool startAtMax = true)
        {
            this.formula = formula;
            if (startAtMax)
            {
                current = formula.Value;
            }
        }

        public int Value
        {
            get { return Mathf.Min(formula.Value, current); }
            set { current = value; }
        }

        public float Fraction
        {
            get { return (float) Value / (float) Max; }
        }

        public int Max
        {
            get { return formula.Value; }
        }
    }
}
