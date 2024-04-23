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

        public Product GetProductById(int id)
        {
            return new Product()
            {
                Id = "7777",
                Name = "Biriyani",
                EntryDate = "2022",
                Price = 100
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return _rabbitmqService.GetProducts().Result;
        }
    }
}
