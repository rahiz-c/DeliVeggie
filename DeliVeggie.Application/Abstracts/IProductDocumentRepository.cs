using DeliVeggie.Domain;

namespace DeliVeggie.Application.Abstracts
{
    public interface IProductDocumentRepository
    {
        IEnumerable<Product> GetProducts(int offset, int limit);

        Product GetProductById(string id);
    }
}
