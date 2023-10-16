using LiteDB;

namespace CartingService.Entities
{
    public class Cart
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string UniqueId { get; set; } = null!;

        public List<CartItem> Items { get; set; } = new();
    }
}