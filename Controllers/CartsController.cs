using Asp.Versioning;
using CartingService.BusinessLogic;
using CartingService.Entities;
using CartingService.Models.RequestModels;
using CartingService.Models.ResponseModels;
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

        [ApiVersion(1.0)]
        [HttpGet("{uniqueId}")]
        [ProducesResponseType(typeof(IEnumerable<ResponseCart>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Cart>> GetCart(string uniqueId)
        {
            var cart = _cartService.GetCart(uniqueId);
            return Ok(cart);
        }

        [ApiVersion(2.0)]
        [HttpGet("{uniqueId}")]
        [ProducesResponseType(typeof(IEnumerable<ResponseCartItem>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ResponseCartItem>> GetCartItems(string uniqueId)
        {
            var cart = _cartService.GetCartItems(uniqueId);
            return Ok(cart);
        }

        [ApiVersion(1.0)]
        [HttpPost("{uniqueId}")]
        [ProducesResponseType(typeof(ResponseCart), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddItem(string uniqueId, [FromBody] AddCartItemRequest item)
        {
            var cart = _cartService.AddItem(uniqueId, item);
            return CreatedAtAction(nameof(GetCart), new {uniqueId = cart.UniqueId}, cart);
        }

        [ApiVersion(1.0)]
        [HttpDelete("{uniqueId}/{itemId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RemoveItem(string uniqueId, int itemId)
        {
            _cartService.RemoveItem(uniqueId, itemId);
            return Ok();
        }
    }
}
