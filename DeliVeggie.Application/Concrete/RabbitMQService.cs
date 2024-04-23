using DeliVeggie.Application.Abstracts;
using DeliVeggie.Domain;
using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliVeggie.Application.Concrete
{
    public class RabbitMQService : IRabbitMQService
    {
        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var bus = RabbitHutch.CreateBus("host=localhost:15672");
            ProductListRequest request = new ProductListRequest()
            {
                offset = 0,
                Limit = 10,
            };
            var response = await bus.Rpc.RequestAsync<ProductListRequest, IEnumerable<Product>>(request);

            return response;
        }
    }
}
