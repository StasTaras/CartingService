namespace CartingService.RequestModels
{
    public class AddCartItemRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string AltText { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}