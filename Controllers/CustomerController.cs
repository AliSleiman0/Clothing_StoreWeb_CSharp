using ClothingStore.Services.DTOs;
using ClothingStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clothing_Store_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _CustomerService;

        public CustomerController(ICustomerService customerService)

        {
            _CustomerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            return Ok(await _CustomerService.GetAllCustomersAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            return Ok(await _CustomerService.GetCustomerByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] SetCustomerDTO SetCustomerDTO)
        {
            return Ok(await _CustomerService.CreateCustomerAsync(SetCustomerDTO));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] SetCustomerDTO SetCustomerDTO)
        {
            return Ok(await _CustomerService.UpdateCustomerAsync(SetCustomerDTO));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            return Ok(await _CustomerService.DeleteCustomerAsync(id));
        }

    }
}
