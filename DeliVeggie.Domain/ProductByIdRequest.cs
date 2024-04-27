namespace DeliVeggie.Domain
{
    public class ProductByIdRequest
    {
        public ProductByIdRequest(string id)
        {
            ProductId = id;
        }
        public string ProductId { get; set; }
    }
}
