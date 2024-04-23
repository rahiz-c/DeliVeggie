using Infrastructure.Core.Repository;
using Infrastructure.MDO;
using DeliVeggie.Domain;
using MongoDB.Driver;
using DataAccess.MDO;

namespace Infrastructure.Repository
{
    public class PriceReductionMdoRepository: MongoDbRepository<PriceReductionsMDO, PriceReduction, string>
    {
        public double GetPriceReductionByDayOfWeek(int dayOfWeek)
        {
            FilterDefinitionBuilder<PriceReductionsMDO> filterBuilder = Builders<PriceReductionsMDO>.Filter;
            FilterDefinition<PriceReductionsMDO> filterDefinition = filterBuilder.Eq(x=> x.DayOfWeek, dayOfWeek);

            var priceReductions = collection.Find(filterDefinition).FirstOrDefault();
            return priceReductions.Reduction;
        }
    }
}
