namespace DeliVeggie.Domain
{
    public class ProductListRequest
    {
        public ProductListRequest(int offset, int limit) {
           Offset = offset;
            Limit = limit;
        }
        public int Offset { get; set; }
        public int Limit { get; set; }

    }
}
