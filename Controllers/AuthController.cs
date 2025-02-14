using ClothingStore.Domain.Models;
using ClothingStore.Services.DTOs.user;
using ClothingStore.Services.Interfaces;
using ClothingStore.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Solvit.API.Controllers.Common.Users
{
    [ApiController]
    [Route("api/user/auth")]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthService _userAuthService;
        private readonly IUserService _userService;

        public UserAuthController(IUserAuthService userAuthService, IUserService userService)
        {
            _userAuthService = userAuthService;
            _userService = userService;
        }
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            // Instead of ClaimTypes.NameIdentifier, use "UserID"
            var userIdString = User.FindFirst("Id")?.Value;

            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
            {
                return Unauthorized("Invalid token");
            }

            var user = await _userService.GetUserAsync(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            // Return sanitized user data (exclude sensitive fields like passwords)
            return Ok(new
            {
                user.Id,
                user.Name,
                user.Email
            });
        }


        #region APIs
        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<UserAuthDTO> Signup([FromBody] UserSignupDTO signupDTO)
        {
            return await _userAuthService.SignupAsync(signupDTO);
        }
        /// <summary>
        /// Used by user to login
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<UserAuthDTO> Login([FromBody] UserLoginDTO loginDTO)
        {
            return await _userAuthService.LoginAsync(loginDTO);
        }

        /// <summary>
        /// Used by user to logout(UI deletes access token and server deletes refresh token from database)
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] User user)
        {
            return Ok(await _userAuthService.LogoutAsync(user));
        }

        /// <summary>
        /// Used by user to genarete a new acces and refresh tokens by submitting current refresh token
        /// </summary>
        /// <param name="refreshUserTokenDTO"></param>
        /// <returns></returns>
        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> RegenerateRefreshToken([FromBody] RefreshUserTokenDTO refreshUserTokenDTO)
        {
            return Ok(await _userAuthService.RegenerateTokensAsync(refreshUserTokenDTO));
        }

        /// <summary>
        /// Used by user to change password
        /// </summary>
        /// <param name="userChangePassDTO"></param>
        /// <returns></returns>
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] UserChangePassDTO userChangePassDTO) // Bind from the body
    
        {
            return Ok(await _userAuthService.ChangePasswordAsync(userChangePassDTO));
        }
        #endregion APIs
    }
}