
namespace Spark
{
    public class ResourceInt
    {
        private FormulaInt formula;
        private int current = 0;

        public ResourceInt (FormulaInt formula)
        {
            this.formula = formula;
        }

        public int Value
        {
            get { return (int)formula.Value + current; }
            set { current = value; }
        }

        public int Max
        {
            get { return formula.Value; }
        }
    }
}
