
using EasyNetQ;
using DeliVeggie.Domain;
using Infrastructure.Repository;
using Infrastructure.MDO;
internal class Program
{
    private static async Task Main(string[] args)
    {
        var bus = RabbitHutch.CreateBus("host=localhost:15672");
        await bus.Rpc.RespondAsync<ProductListRequest, IEnumerable<Product>>(request => GetProducts(request.Offset, request.Limit));

        await bus.Rpc.RespondAsync<ProductByIdRequest, Product>(request=>GetProductById(request.ProductId));
    }


    private static Product GetProductById(string productId)
    {
        ProductMdoRepository productMdoRepository = new ProductMdoRepository();
        var response = productMdoRepository.GetProductsById(productId);
        return response;
    }

    private static IEnumerable<Product> GetProducts(int offset, int limit)
    {
        ProductMdoRepository productMdoRepository = new ProductMdoRepository();

        var response =  productMdoRepository.GetProducts(offset, limit);

        foreach (var item in response)
        {
            item.Price = GetReducedPrice(item.Price);
        }

        return response;
    }

    private static double GetReducedPrice(double price)
    {
        int dayOfWeek = ((int)DateTime.Now.DayOfWeek) + 1;
        PriceReductionMdoRepository priceReductionMdoRepository = new PriceReductionMdoRepository();
        double reduction = priceReductionMdoRepository.GetPriceReductionByDayOfWeek(dayOfWeek);
        return price - reduction;
    }
}