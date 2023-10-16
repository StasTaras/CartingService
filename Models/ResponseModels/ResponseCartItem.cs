namespace CartingService.Models.ResponseModels
{
    public class ResponseCartItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ResponseCartItemImage? Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}