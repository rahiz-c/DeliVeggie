using Infrastructure.Core;
using System.Runtime.Serialization;

namespace Infrastructure.MDO
{
    [CollectionName("Products")]
    public class ProductMdo:MongoDataObject
    {
        [DataMember]
        public string  Name { get; set; }

        [DataMember] 
        public DateTime EntryDate { get; set; }

        [DataMember]
        public double Price { get; set; }
    }
}
