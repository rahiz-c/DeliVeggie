using DeliVeggie.Domain;

namespace DeliVeggie.Application.Abstracts
{
    public interface IMongoService
    {
        IEnumerable<Product> GetProducts();
    }
}
