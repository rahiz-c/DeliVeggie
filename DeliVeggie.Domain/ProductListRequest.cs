using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliVeggie.Domain
{
    public class ProductListRequest
    {
        public int offset { get; set; }
        public int Limit { get; set; }
    }
}
