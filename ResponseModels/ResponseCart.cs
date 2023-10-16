namespace CartingService.ResponseModels
{
    public class ResponseCart
    {
        public string UniqueId { get; set; } = null!;
        public List<ResponseCartItem> Items { get; set; } = new();
    }
}