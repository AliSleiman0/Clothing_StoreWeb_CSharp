using ClothingStore.Services.DTOs;
using ClothingStore.Services.Interfaces;
using ClothingStore.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clothing_Store_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private CartItemService _cartItemService;

        public CartItemController(CartItemService cartItemService)
        {
            _cartItemService = cartItemService;
            
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCartItemsByCartIdAsync(int CartId)
        {
            return Ok(await _cartItemService.GetCartItemsByCartIdAsync(CartId));
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItemAsync([FromBody] SetCartItemDTO setCartItemDTO)
        {
            return Ok(await _cartItemService.AddCartItemAsync(setCartItemDTO));
        }
       
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCartItemAsync(int cartItemId)
        {
            return Ok(await _cartItemService.DeleteCartItemAsync(cartItemId));
        }

    }
}
