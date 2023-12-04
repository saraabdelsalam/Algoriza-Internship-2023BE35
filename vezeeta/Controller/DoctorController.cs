using Core_Layer.DTOs;
using Core_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace vezeeta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorServices _doctor;

        public DoctorController(IDoctorServices Doctor)
        {
            _doctor= Doctor;
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

                return await _doctor.SignInUser(UserDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Signing In: {ex.Message}");
            }

        }



        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut()
        {
           await _doctor.LogOut();
            return Ok("LogOut Successfully");
        }

    }
}
