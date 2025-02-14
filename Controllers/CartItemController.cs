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
        private ICartItemsService _cartItemService;

        public CartItemController(ICartItemsService cartItemService)
        {
            _cartItemService = cartItemService;
            
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCartItemsByCartIdAsync(int id)
        {
            return Ok(await _cartItemService.GetCartItemsByCartIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItemAsync([FromBody] SetCartItemDTO setCartItemDTO)
        {
            return Ok(await _cartItemService.AddCartItemAsync(setCartItemDTO));
        }
       
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCartItemAsync(int id)
        {
            return Ok(await _cartItemService.DeleteCartItemAsync(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, [FromBody] SetCartItemDTO updateDto)
        {
            try
            {
                var result = await _cartItemService.UpdateCartItemAsync(id, updateDto);
                return result ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
