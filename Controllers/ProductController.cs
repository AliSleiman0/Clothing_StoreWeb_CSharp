using ClothingStore.Domain.Enums;
using ClothingStore.Domain.Models;
using ClothingStore.Services.DTOs;
using ClothingStore.Services.Interfaces;
using ClothingStore.Services.Services;
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
            
        }
        [HttpGet] 
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _ProductService.GetAllProductsAsync());
        }
        [HttpGet("GetTopSellingProductsAsync")] 
        public async Task<IActionResult> GetTopSellingProductsAsync()
        {
            return Ok(await _ProductService.GetTopSellingProductsAsync());
        }
        [HttpGet("GetAllProducts")]
        public async Task<List<ProductCardDTO>> GetAllProducts([FromQuery] Gender gender)
        {
           
                return await _ProductService.GetAllProductsDataAsync(gender);
              
        }
        [HttpGet("singleProductCard/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductCardDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductCardDTO>> GetProductCardById(int id)
        {
            return Ok(await _ProductService.GetProductCardByIdAsync(id));
        }
        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _ProductService.GetProductByIdAsync(id));
        }

        [HttpGet("GetProductWithStocks/{id:int}")] 
        public async Task<IActionResult> GetProductWithStocks(int id)
        {
            return Ok(await _ProductService.GetProductWithStocks(id));
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDTO addProductDto)
        {
            try
            {
                await _ProductService.AddProduct(addProductDto);
                return Ok(new { Message = "Product added successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "An error occurred while adding the product.", Error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductDTO productDTO)
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
