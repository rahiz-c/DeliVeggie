using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Core
{
    public interface IMongoDataObject<TKey>
    {
        [BsonId]
        TKey Id { get; }
    }
}
