using CartingService.DAL;
using CartingService.Entities;
using CartingService.Models.RequestModels;
using CartingService.Models.ResponseModels;

namespace CartingService.BusinessLogic
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public ResponseCart GetCart(string uniqueId)
        {
            var cart = _cartRepository.GetCart(uniqueId);
            return new ResponseCart
            {
                UniqueId = cart.UniqueId,
                Items = cart.Items.Select(MapToResponseItem).ToList()
            };
        }

        public IEnumerable<ResponseCartItem> GetCartItems(string uniqueId)
        {
            var cart = _cartRepository.GetCart(uniqueId);
            return cart.Items
                .Select(item => new ResponseCartItem
                {
                    Id = item.Id,
                    Image = new ResponseCartItemImage(
                        item.Image != null ? item.Image.Url : string.Empty,
                        item.Image != null ? item.Image.AltText : string.Empty),
                    Name = item.Name,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
        }

        public ResponseCart AddItem(string uniqueId, AddCartItemRequest requestItem)
        {
            var item = new CartItem
            {
                Id = requestItem.Id,
                Name = requestItem.Name,
                Image = new Image
                {
                    AltText = requestItem.AltText,
                    Url = requestItem.ImageUrl
                },
                Price = requestItem.Price,
                Quantity = requestItem.Quantity,
            };

            var cart = _cartRepository.AddItem(uniqueId, item);
            return new ResponseCart
            {
                UniqueId = cart.UniqueId,
                Items = cart.Items.Select(MapToResponseItem).ToList()
            };
        }

        public void RemoveItem(string uniqueId, int itemId)
        {
            _cartRepository.RemoveItem(uniqueId, itemId);
        }

        private static ResponseCartItem MapToResponseItem(CartItem item)
        {
            return new ResponseCartItem
            {
                Id = item.Id,
                Name = item.Name,
                Image = item.Image != null ? new ResponseCartItemImage(item.Image.AltText, item.Image.Url) : null,
                Price = item.Price,
                Quantity = item.Quantity,
            };
        }
    }
}