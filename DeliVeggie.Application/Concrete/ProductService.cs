using DeliVeggie.Application.Abstracts;
using DeliVeggie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliVeggie.Application.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IRabbitMQService _rabbitmqService;

        public ProductService(IRabbitMQService rabbitmqService)
        {
            _rabbitmqService = rabbitmqService;
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _rabbitmqService.GetProductById(id);
        }

        public async Task<IEnumerable<Product>> GetProducts(int offset, int limit)
        {
            return await _rabbitmqService.GetProducts(offset, limit);
        }
    }
}
