using ClothingStore.Services.DTOs;
using ClothingStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clothing_Store_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _OrderService;

        public OrderController(IOrderService orderService)
        {
            _OrderService = orderService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            return Ok(await _OrderService.GetAllOrdersAsync());
        }
        [HttpGet("order/{id:int}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            return Ok(await _OrderService.GetOrderByIdAsync(id));
        }

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetCustomerOrdersAsync(int customerId)
        {
            return Ok(await _OrderService.GetCustomerOrdersAsync(customerId));
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrderAsync([FromBody] SetOrderDTO setOrderDTO)
        {
            return Ok(await _OrderService.PlaceOrderAsync(setOrderDTO));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderStatusAsync([FromBody] string status, int orderId)
        {
            return Ok(await _OrderService.UpdateOrderStatusAsync(status, orderId));
        }
        [HttpDelete]
        public async Task<IActionResult> CancelOrderAsync(int id)
        {
            return Ok(await _OrderService.CancelOrderAsync(id));
        }

    }
}
