
using System.Collections.Generic;

namespace Spark
{
    public class FormulaInt
    {
        private int value;

        private List<FormulaInt> formulaAdds = new List<FormulaInt>();
        private List<UnitStat> statAdds = new List<UnitStat>();
        private List<int> adds = new List<int>();

        private List<FormulaInt> formulaMuls = new List<FormulaInt>();
        private List<UnitStat> statMuls = new List<UnitStat>();
        private List<int> muls = new List<int>();

        public FormulaInt (int value = 0)
        {
            this.value = value;
        }

        public FormulaInt Add (FormulaInt formula)
        {
            formulaAdds.Add(formula);
            return this;
        }

        public FormulaInt Add (UnitStat stat)
        {
            statAdds.Add(stat);
            return this;
        }

        public FormulaInt Add (int amount)
        {
            adds.Add(amount);
            return this;
        }

        public FormulaInt Multiply (FormulaInt formula)
        {
            formulaMuls.Add(formula);
            return this;
        }

        public FormulaInt Multiply (UnitStat stat)
        {
            statMuls.Add(stat);
            return this;
        }

        public FormulaInt Multiply (int amount)
        {
            muls.Add(amount);
            return this;
        }

        private int CalcAdd (List<FormulaInt> formulas)
        {
            int tot = 0;
            foreach (FormulaInt f in formulas)
            {
                tot += f.Value;
            }
            return tot;
        }

        private int CalcAdd (List<UnitStat> stats)
        {
            int tot = 0;
            foreach (UnitStat s in stats)
            {
                tot += s.Value;
            }
            return tot;
        }

        private int CalcAdd (List<int> values)
        {
            int tot = 0;
            foreach (int v in values)
            {
                tot += v;
            }
            return tot;
        }

        private int CalcMul (List<FormulaInt> formulas)
        {
            int tot = 1;
            foreach (FormulaInt f in formulas)
            {
                tot *= f.Value;
            }
            return tot;
        }

        private int CalcMul (List<UnitStat> stats)
        {
            int tot = 1;
            foreach (UnitStat s in stats)
            {
                tot *= s.Value;
            }
            return tot;
        }

        private int CalcMul (List<int> values)
        {
            int tot = 1;
            foreach (int v in values)
            {
                tot *= v;
            }
            return tot;
        }

        public int Value
        {
            get
            {
                return value * CalcMul(formulaMuls) * CalcMul(statMuls) * CalcMul(muls)
                    + (CalcAdd(formulaAdds) + CalcAdd(statAdds) + CalcAdd(adds));
            }
        } 
    }
}