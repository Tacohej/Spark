
namespace Spark
{
    public class UnitVar 
    {
        private UnitStat unitStat;
        private int current = 0;

        public int Value
        {
            get { return unitStat.Value + current; }
            set { current = value; }
        }

        public int Max
        {
            get { return unitStat.Value; }
        }

        public UnitVar (UnitStat unitStat)
        {
            this.unitStat = unitStat;
        }

    }
}
