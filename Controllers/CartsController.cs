using CartingService.BusinessLogic;
using CartingService.Entities;
using CartingService.Models.RequestModels;
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
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        public IActionResult GetCart(string uniqueId)
        {
            var cart = _cartService.GetCart(uniqueId);
            return Ok(cart);
        }

        [HttpPost("{uniqueId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddItem(string uniqueId, [FromBody] AddCartItemRequest item)
        {
            var cart = _cartService.AddItem(uniqueId, item);
            return CreatedAtAction(nameof(GetCart), new {uniqueId = cart.UniqueId}, cart);
        }

        [HttpDelete("{uniqueId}/{itemId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult RemoveItem(string uniqueId, int itemId)
        {
            _cartService.RemoveItem(uniqueId, itemId);
            return NoContent();
        }
    }
}