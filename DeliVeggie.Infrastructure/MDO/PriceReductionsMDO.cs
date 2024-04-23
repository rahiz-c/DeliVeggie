using Infrastructure.Core;
using System.Runtime.Serialization;

namespace DataAccess.MDO
{
    [CollectionName("PriceReductions")]
    public class PriceReductionsMDO:MongoDataObject
    {
        [DataMember]
        public int DayOfWeek { get; set; }

        [DataMember]
        public double Reduction { get; set; }
    }
}
