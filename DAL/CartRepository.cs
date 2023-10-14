using CartingService.Models;
using LiteDB;
namespace CartingService.DAL
{
    public class CartRepository : ICartRepository
    {
        private const string CARTS_COLLECTION = "Carts";
        private readonly LiteDatabase _liteDb;

        public CartRepository(string connectionString)
        {
            _liteDb = new LiteDatabase(connectionString);
        }

        public Cart GetCart(string uniqueId)
        {
            return _liteDb.GetCollection<Cart>(CARTS_COLLECTION).FindOne(c => c.UniqueId == uniqueId)
                   ?? new Cart { UniqueId = uniqueId };
        }

        public void AddItem(string uniqueId, CartItem item)
        {
            var cart = GetCart(uniqueId);

            if (cart.Items == null)
            {
                cart.Items = new List<CartItem>();
            }

            cart.Items.Add(item);

            if (_liteDb.GetCollection<Cart>(CARTS_COLLECTION).Exists(c => c.UniqueId == uniqueId))
            {
                _liteDb.GetCollection<Cart>(CARTS_COLLECTION).Update(cart);
            }
            else
            {
                _liteDb.GetCollection<Cart>(CARTS_COLLECTION).Insert(cart);
            }
        }

        public void RemoveItem(string uniqueId, int itemId)
        {
            var cart = GetCart(uniqueId);
            cart.Items.RemoveAll(i => i.Id == itemId);
            _liteDb.GetCollection<Cart>(CARTS_COLLECTION).Update(cart);
        }
    }
}