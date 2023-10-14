using LiteDB;

namespace CartingService.Models
{
    public class Cart
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string UniqueId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}