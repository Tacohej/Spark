using System.Collections.Generic;

namespace Spark
{
    public class FormulaFloat
    {
        private float initValue;
        private UnitStat initStat;

        private List<FormulaFloat> formulaAdds = new List<FormulaFloat>();
        private List<UnitStat> statAdds = new List<UnitStat>();
        private List<float> adds = new List<float>();

        private List<FormulaFloat> formulaMuls = new List<FormulaFloat>();
        private List<UnitStat> statMuls = new List<UnitStat>();
        private List<float> muls = new List<float>();

        public FormulaFloat (float value)
        {
            this.initValue = value;
        }

        public FormulaFloat (UnitStat stat)
        {
            this.initStat = stat;
        }

        public FormulaFloat Add (FormulaFloat formula)
        {
            formulaAdds.Add(formula);
            return this;
        }

        public FormulaFloat Add (UnitStat stat)
        {
            statAdds.Add(stat);
            return this;
        }

        public FormulaFloat Add (float amount)
        {
            adds.Add(amount);
            return this;
        }

        public FormulaFloat Multiply (FormulaFloat formula)
        {
            formulaMuls.Add(formula);
            return this;
        }

        public FormulaFloat Multiply (UnitStat stat)
        {
            statMuls.Add(stat);
            return this;
        }

        public FormulaFloat Multiply (float amount)
        {
            muls.Add(amount);
            return this;
        }

        private float CalcAdd (List<FormulaFloat> formulas)
        {
            float tot = 0;
            foreach (FormulaFloat f in formulas)
            {
                tot += f.Value;
            }
            return tot;
        }

        private float CalcAdd (List<UnitStat> stats)
        {
            float tot = 0;
            foreach (UnitStat s in stats)
            {
                tot += s.Value;
            }
            return tot;
        }

        private float CalcAdd (List<float> values)
        {
            float tot = 0;
            foreach (float v in values)
            {
                tot += v;
            }
            return tot;
        }

        private float CalcMul (List<FormulaFloat> formulas)
        {
            float tot = 1;
            foreach (FormulaFloat f in formulas)
            {
                tot *= f.Value;
            }
            return tot;
        }

        private float CalcMul (List<UnitStat> stats)
        {
            float tot = 1;
            foreach (UnitStat s in stats)
            {
                tot *= s.Value;
            }
            return tot;
        }

        private float CalcMul (List<float> values)
        {
            float tot = 1;
            foreach (float v in values)
            {
                tot *= v;
            }
            return tot;
        }

        public float Value
        {
            get
            {
                var value = initStat != null ? initStat.Value : initValue;
                return value * CalcMul(formulaMuls) * CalcMul(statMuls) * CalcMul(muls)
                    + (CalcAdd(formulaAdds) + CalcAdd(statAdds) + CalcAdd(adds));
            }
        } 
    }
}