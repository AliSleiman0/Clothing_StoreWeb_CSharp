using ClothingStore.Services.DTOs;
using ClothingStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clothing_Store_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _ProductService;

        public ProductController(IProductService productService)
        {
            _ProductService = productService;
;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _ProductService.GetAllProductsAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _ProductService.GetProductByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] AddProductDTO productDTO)
        {
            return Ok(await _ProductService.AddProductAsync(productDTO));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] AddProductDTO productDTO)
        {
            return Ok(await _ProductService.UpdateProductAsync(productDTO));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            return Ok(await _ProductService.DeleteProductAsync(id));
        }

    }
}
