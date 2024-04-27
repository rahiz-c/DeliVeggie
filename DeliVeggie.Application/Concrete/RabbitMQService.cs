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
             bus = RabbitHutch.CreateBus("host=localhost", register=>register.EnableConsoleLogger());
        }
        public async Task<Product> GetProductById(string id)
        {
            try
            {
                ProductByIdRequest request = new ProductByIdRequest(id);
                var product = await bus.Rpc.RequestAsync<ProductByIdRequest, Product>(request);
                return product;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            
        }

        public async Task<IEnumerable<Product>> GetProducts(int offset, int limit = 10)
        {
            ProductListRequest request = new ProductListRequest(offset, limit);
            
            try
            {
                var products = await bus.Rpc.RequestAsync<ProductListRequest, IEnumerable<Product>>(request);
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }       
    }
}
