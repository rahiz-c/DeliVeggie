using System.Runtime.Serialization;

namespace DeliVeggie.Domain
{
    public class PriceReduction
    {
        public int DayOfWeek { get; set; }
        public double Reductions { get; set; }
    }
}
