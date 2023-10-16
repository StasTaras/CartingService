using CartingService.Models;

namespace CartingService.BusinessLogic
{
    public interface ICartService
    {
        Cart GetCart(string uniqueId);

        void AddItem(string uniqueId, CartItem item);

        void RemoveItem(string uniqueId, int itemId);
    }
}