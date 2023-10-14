using CartingService.BusinessLogic;
using CartingService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{uniqueId}")]
        public Cart GetCart(string uniqueId)
        {
            return _cartService.GetCart(uniqueId);
        }

        [HttpPost("{uniqueId}")]
        public void AddItem(string uniqueId, [FromBody] CartItem item)
        {
            _cartService.AddItem(uniqueId, item);
        }

        [HttpDelete("{uniqueId}/{itemId}")]
        public void RemoveItem(string uniqueId, int itemId)
        {
            _cartService.RemoveItem(uniqueId, itemId);
        }
    }
}