using CartingService.Models;
namespace CartingService.DAL
{
    public interface ICartRepository
    {
        Cart GetCart(string uniqueId);
        void AddItem(string uniqueId, CartItem item);
        void RemoveItem(string uniqueId, int itemId);
    }
}