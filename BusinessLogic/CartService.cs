using CartingService.DAL;
using CartingService.Models;

namespace CartingService.BusinessLogic
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Cart GetCart(string uniqueId)
        {
            return _cartRepository.GetCart(uniqueId);
        }

        public void AddItem(string uniqueId, CartItem item)
        {
            _cartRepository.AddItem(uniqueId, item);
        }

        public void RemoveItem(string uniqueId, int itemId)
        {
            _cartRepository.RemoveItem(uniqueId, itemId);
        }
    }
}
