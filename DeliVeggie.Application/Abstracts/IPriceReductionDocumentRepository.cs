namespace DeliVeggie.Application.Abstracts
{
    public interface IPriceReductionDocumentRepository
    {
        double GetPriceReductionByDayOfWeek(int dayOfWeek);
    }
}
