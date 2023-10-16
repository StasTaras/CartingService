using CartingService.Models;
using LiteDB;
namespace CartingService.DAL
{
    public class CartRepository : ICartRepository
    {
        private const string CartsCollection = "Carts";
        private readonly LiteDatabase _liteDb;

        public CartRepository(string connectionString)
        {
            _liteDb = new LiteDatabase(connectionString);
        }

        public Cart GetCart(string uniqueId)
        {
            return _liteDb.GetCollection<Cart>(CartsCollection).FindOne(c => c.UniqueId == uniqueId)
                   ?? new Cart { UniqueId = uniqueId };
        }

        public void AddItem(string uniqueId, CartItem item)
        {
            var cart = GetCart(uniqueId);

            cart.Items.Add(item);

            if (_liteDb.GetCollection<Cart>(CartsCollection).Exists(c => c.UniqueId == uniqueId))
            {
                _liteDb.GetCollection<Cart>(CartsCollection).Update(cart);
            }
            else
            {
                _liteDb.GetCollection<Cart>(CartsCollection).Insert(cart);
            }
        }

        public void RemoveItem(string uniqueId, int itemId)
        {
            var cart = GetCart(uniqueId);
            cart.Items.RemoveAll(i => i.Id == itemId);
            _liteDb.GetCollection<Cart>(CartsCollection).Update(cart);
        }
    }
}