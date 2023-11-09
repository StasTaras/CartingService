using CartingService.Models.RequestModels;
using CartingService.Models.ResponseModels;

namespace CartingService.BusinessLogic
{
    public interface ICartService
    {
        ResponseCart GetCart(string uniqueId);

        IEnumerable<ResponseCartItem> GetCartItems(string uniqueId);

        ResponseCart AddItem(string uniqueId, AddCartItemRequest item);

        void RemoveItem(string uniqueId, int itemId);
    }
}