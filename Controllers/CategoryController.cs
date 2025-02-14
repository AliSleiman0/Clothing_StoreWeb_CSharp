using ClothingStore.Domain.Enums;
using ClothingStore.Services.DTOs;
using ClothingStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clothing_Store_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;

        }
        [HttpGet]
        
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            return Ok(await _CategoryService.GetAllCategoriesAsync());
        }

        [HttpGet("GetTopSellingCategories")]

        public async Task<IActionResult> GetTopSellingCategories()
        {
            return Ok(await _CategoryService.GetTopSellingCategories());
        }

        [HttpGet("GetTopCategoriesByProductCount")]

        public async Task<IActionResult> GetTopCategoriesByProductCount()
        {
            return Ok(await _CategoryService.GetTopCategoriesByProductCount());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            return Ok(await _CategoryService.GetCategoryByIdAsync(id));
        }
        [HttpGet("ProductsByGender")]
        public async Task<IActionResult> GetCategoryByGender([FromQuery] Gender[] gender)
        {
            return Ok(await _CategoryService.GetCategoriesByProductGender(gender));
        }

        [HttpPost]
        public async Task<IActionResult> AddGategoryAsync([FromBody] SetCategoryDTO setCategoryDTO)
        {
            return Ok(await _CategoryService.AddGategoryAsync(setCategoryDTO));
        }
        //[HttpPut]
        //public async Task<IActionResult> UpdateCategoryAsync([FromBody] SetCategoryDTO setCategoryDTO)
        //{
        //    return Ok(await _CategoryService.UpdateCategoryAsync(setCategoryDTO));
        //}
        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            return Ok(await _CategoryService.DeleteCategoryAsync(id));
        }

    }
}
