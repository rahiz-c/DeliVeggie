using Infrastructure.Core.Repository;
using Infrastructure.MDO;
using DeliVeggie.Domain;
using MongoDB.Driver;
using DeliVeggie.Application.Abstracts;

namespace Infrastructure.Repository
{
    public class ProductMdoRepository : MongoDbRepository<ProductMdo, Product, string>, IProductDocumentRepository
    {
                       
        IEnumerable<Product> IProductDocumentRepository.GetProducts(int offset, int limit)
        {
            FilterDefinitionBuilder<ProductMdo> filterBuilder = Builders<ProductMdo>.Filter;
            FilterDefinition<ProductMdo> filterDefinition = filterBuilder.Empty;

            var products = collection.Find(filterDefinition)
                                     .Skip(offset)
                                     .Limit(limit)
                                     .ToList();
            return ToDomain(products);
        }

        Product IProductDocumentRepository.GetProductById(string id)
        {
            FilterDefinitionBuilder<ProductMdo> filterBuilder = Builders<ProductMdo>.Filter;
            FilterDefinition<ProductMdo> filterDefinition = filterBuilder.Eq(x => x.Id, id);

            var product = collection.Find(filterDefinition).FirstOrDefault();
            return ToDomain(product);
        }

        #region PRIVATE METHODS
        private IEnumerable<Product> ToDomain(IList<ProductMdo> products)
        {
            return products.Select(p => new Product()
            {
                Name = p.Name,
                EntryDate = FormatDateWithOrdinal(p.EntryDate),
                Price = p.Price,
            }).ToList();
        }
        private Product ToDomain(ProductMdo product)
        {
            return new Product()
            {
                Name = product.Name,
                EntryDate = FormatDateWithOrdinal(product.EntryDate),
                Price = product.Price,
            };
        }
        private string GetOrdinalSuffix(int day)
        {
            switch (day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }

        private string FormatDateWithOrdinal(DateTime date)
        {
            string dayWithOrdinal = date.Day + GetOrdinalSuffix(date.Day);
            string monthName = date.ToString("MMMM");
            string year = date.Year.ToString();

            return $"{dayWithOrdinal} of {monthName} {year}";
        }

        


        #endregion
    }
}
