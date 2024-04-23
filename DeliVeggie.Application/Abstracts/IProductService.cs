using DeliVeggie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliVeggie.Application.Abstracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        Product GetProductById(int id);
    }
}
