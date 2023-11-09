using CartingService.Entities;
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
            return _liteDb
                       .GetCollection<Cart>(CartsCollection)
                       .FindOne(c => c.UniqueId == uniqueId)
                   ?? new Cart { UniqueId = uniqueId };
        }

        public Cart AddItem(string uniqueId, CartItem item)
        {
            var cart = GetCart(uniqueId);

            var cartExists = _liteDb.GetCollection<Cart>(CartsCollection).Exists(c => c.UniqueId == uniqueId);

            if (!cartExists)
            {
                cart = new Cart
                {
                    UniqueId = uniqueId,
                    Items = new List<CartItem> { item }
                };

                _liteDb.GetCollection<Cart>(CartsCollection).Insert(cart);
            }
            else
            {
                var existingItem = cart.Items.FirstOrDefault(i => i.Id == item.Id);

                if (existingItem != null)
                {
                    existingItem.Quantity += item.Quantity;
                }
                else
                {
                    cart.Items.Add(item);
                }
                
                _liteDb.GetCollection<Cart>(CartsCollection).Update(cart);
            }

            return cart;
        }

        public void RemoveItem(string uniqueId, int itemId)
        {
            var cart = GetCart(uniqueId);
            cart.Items.RemoveAll(i => i.Id == itemId);
            _liteDb.GetCollection<Cart>(CartsCollection).Update(cart);
        }
    }
}