
namespace Spark
{
    public class ResourceInt
    {
        private UnitStat unitStat;
        private int current = 0;
        private float multiplier = 1;

        public int Value
        {
            get { return (int)(unitStat.Value * multiplier) + current; }
            set { current = value; }
        }

        public int Max
        {
            get { return unitStat.Value; }
        }

        public ResourceInt (UnitStat unitStat)
        {
            this.unitStat = unitStat;
        }

        public void SetMultiplier (float multiplier)
        {
            this.multiplier = multiplier;
        }

    }
}
