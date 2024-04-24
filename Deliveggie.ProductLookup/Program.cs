
using DeliVeggie.Application.Abstracts;
using DeliVeggie.Domain;
using EasyNetQ;
using Infrastructure.Repository;
using RabbitMQ.Client.Exceptions;
internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            var bus = RabbitHutch.CreateBus("host=localhost;port=15672;username=guest;password=guest;requestedHeartbeat=10");
            await bus.Rpc.RespondAsync<ProductListRequest, IEnumerable<Product>>(request => GetProducts(request.Offset, request.Limit));

            await bus.Rpc.RespondAsync<ProductByIdRequest, Product>(request => GetProductById(request.ProductId));
        }
        catch(BrokerUnreachableException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
    }


    private static Product GetProductById(string productId)
    {
        IProductDocumentRepository productMdoRepository = new ProductMdoRepository();
        var response =  productMdoRepository.GetProductById(productId);
        return response;
    }

    private static IEnumerable<Product> GetProducts(int offset, int limit)
    {
        IProductDocumentRepository productMdoRepository = new ProductMdoRepository();

        var response =   productMdoRepository.GetProducts(offset, limit);

        foreach (var item in response)
        {
            item.Price = GetReducedPrice(item.Price);
        }

        return response;
    }

    private static double GetReducedPrice(double price)
    {
        int dayOfWeek = ((int)DateTime.Now.DayOfWeek) + 1;
        IPriceReductionDocumentRepository priceReductionMdoRepository = new PriceReductionMdoRepository();
        double reduction = priceReductionMdoRepository.GetPriceReductionByDayOfWeek(dayOfWeek);
        return price - reduction;
    }
}