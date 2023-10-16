using CartingService.Entities;

namespace CartingService.DAL
{
    public interface ICartRepository
    {
        Cart GetCart(string uniqueId);

        Cart AddItem(string uniqueId, CartItem item);

        void RemoveItem(string uniqueId, int itemId);
    }
}