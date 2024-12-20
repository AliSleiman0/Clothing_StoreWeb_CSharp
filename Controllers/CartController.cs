using ClothingStore.Services.DTOs;
using ClothingStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clothing_Store_C_.Controllers
{
  

        [Route("api/[controller]")]
        [ApiController]
        public class CartController : ControllerBase
        {
            private ICartService _CartService;

            public CartController(ICartService CartService)
            {
            _CartService = CartService;
                
            }
        
            [HttpGet("{id:int}")]
            public async Task<IActionResult> GetCartByUserIdAsync(int id)
            {
                return Ok(await _CartService.GetCartByUserIdAsync(id));
            }

           
            [HttpPut]
            public async Task<IActionResult> ClearCartAsync(int cartId)
            {
                return Ok(await _CartService.ClearCartAsync(cartId));
            }
           

        }
    }

