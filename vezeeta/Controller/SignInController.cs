using Core_Layer.DTOs;
using Core_Layer.Models;
using Core_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces.Admin;

namespace vezeeta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {

       
        private readonly IAppUserServices _appUserServices;
        
        public SignInController( IAppUserServices appUserServices)
        {
            
            _appUserServices = appUserServices;
           
        }

        [HttpPost("SignIn")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> SignIn([FromForm] SignInDto UserDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };

                return await _appUserServices.SignInUser(UserDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Signing In: {ex.Message}");
            }

        }


        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _appUserServices.LogOut();
            return Ok("LogOut Successfully");
        }

    }
}
