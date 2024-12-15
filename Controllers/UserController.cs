using ClothingStore.Services.DTOs;
using ClothingStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clothing_Store_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers() { 
            return Ok(await _userService.GetAllUsersAsync());        
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await _userService.GetUserAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserDTO userDTO)
        {
            return Ok(await _userService.CreateUserAsync(userDTO));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] AddUserDTO userDTO)
        {
            return Ok(await _userService.UpdateUserAsync(userDTO));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Ok(await _userService.DeleteUserAsync(id));
        }

    }
}
