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
        Task<IEnumerable<Product>> GetProducts(int offset, int limit);

        Task<Product> GetProductById(string id);
    }
}
