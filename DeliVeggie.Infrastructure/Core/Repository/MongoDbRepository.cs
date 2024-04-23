using MongoDB.Driver;

namespace Infrastructure.Core.Repository
{
    public class MongoDbRepository<T, TDocument, TKey> where T : IMongoDataObject<TKey>
    {
        protected IMongoCollection<T> collection;

        public MongoDbRepository() : this((string)Utility<TKey, TDocument>.GetConnectionString())
        {

        }

        public MongoDbRepository(string connectionString)
        {
            collection = Utility<TKey, TDocument>.GetCollectionFromConnectionString<T>(connectionString);
        }
    }
}
