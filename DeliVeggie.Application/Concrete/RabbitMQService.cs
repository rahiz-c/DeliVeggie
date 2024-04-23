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
        private readonly IBus bus;
        public RabbitMQService()
        {
             bus = RabbitHutch.CreateBus("host=localhost:15672");
        }
        public async Task<Product> GetProductById(string id)
        {
            ProductByIdRequest request = new ProductByIdRequest() { ProductId = id};
            var product = await bus.Rpc.RequestAsync<ProductByIdRequest, Product>(request);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts(int offset, int limit)
        {
            ProductListRequest request = new ProductListRequest()
            {
                offset = offset,
                Limit = limit,
            };
            var response = await bus.Rpc.RequestAsync<ProductListRequest, IEnumerable<Product>>(request);

            return response;
        }
    }
}
