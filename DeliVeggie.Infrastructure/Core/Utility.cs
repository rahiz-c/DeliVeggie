using MongoDB.Driver;

namespace Infrastructure.Core
{
    public static class Utility<U, TDocument>
    {
        private const string DefaultConnectionStringName = "MongoServerSettings";

        public static string GetConnectionString()
        {

            return "mongodb://localhost:27017/DeliVeggie";
        }

        public static IMongoCollection<T> GetCollectionFromConnectionString<T>(string connectionString) where T : IMongoDataObject<U>
        {
            return GetCollectionFromUrl<T>(new MongoUrl(connectionString), GetCollectionName<T>());
        }


        public static IMongoCollection<T> GetCollectionFromUrl<T>(MongoUrl url, string collectionName) where T : IMongoDataObject<U>
        {
            return GetDatabaseFromUrl(url).GetCollection<T>(collectionName);
        }

        #region PRIVATE METHODS

        private static IMongoDatabase GetDatabaseFromUrl(MongoUrl mongoUrl)
        {
            var client = new MongoClient(mongoUrl);
            return client.GetDatabase(mongoUrl.DatabaseName);
        }

        private static string GetCollectionName<T>() where T : IMongoDataObject<U>
        {
            if (typeof(T).IsInterface)
            {
                return GetCollectionNameFromInterface<T>();
            }
            else
            {
                return GetCollectionNameFromType(typeof(T));
            }
        }

        private static string GetCollectionNameFromInterface<T>()
        {
            string collectionName;
            var attr = Attribute.GetCustomAttribute(typeof(T), typeof(CollectionName));

            if (attr != null)
            {
                collectionName = ((CollectionName)attr).Name;
            }
            else
            {
                collectionName = typeof(T).Name;
            }

            return collectionName;
        }

        private static string GetCollectionNameFromType(Type entityType)
        {
            string collectionName;
            var attr = Attribute.GetCustomAttribute(entityType, typeof(CollectionName));
            if (attr != null)
            {
                collectionName = ((CollectionName)attr).Name;
            }
            else
            {
                while (!entityType.BaseType.Equals(typeof(MongoDataObject)))
                {
                    entityType = entityType.BaseType;
                }

                collectionName = entityType.Name;
            }

            return collectionName;
        }
        #endregion
    }
}
