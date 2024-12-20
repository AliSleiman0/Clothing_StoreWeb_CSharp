using ClothingStore.Services.DTOs;
using ClothingStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clothing_Store_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private IOrderItemsService _OrderItemsService;

        public OrderItemController(IOrderItemsService OrderItemsService)
        {
            _OrderItemsService = OrderItemsService;
          
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderItemsByOrderId(int id)
        {
            return Ok(await _OrderItemsService.GetOrderItemsByOrderId(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderItemAsync([FromBody] SetOrderProductDTO orderProductDTO)
        {
            return Ok(await _OrderItemsService.AddOrderItemAsync(orderProductDTO));
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItemAsync(int id)
        {
            return Ok(await _OrderItemsService.DeleteOrderItemAsync(id));
        }

    }
}
