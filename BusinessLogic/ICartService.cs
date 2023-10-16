using CartingService.RequestModels;
using CartingService.ResponseModels;

namespace CartingService.BusinessLogic
{
    public interface ICartService
    {
        ResponseCart GetCart(string uniqueId);

        ResponseCart AddItem(string uniqueId, AddCartItemRequest item);

        void RemoveItem(string uniqueId, int itemId);
    }
}