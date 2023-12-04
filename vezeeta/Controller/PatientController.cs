using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Models;
using Core_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace vezeeta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _Patient;
        public PatientController(IPatientServices patient) {
            _Patient = patient;
        }
        [HttpPost("Register")]
        [Consumes("multipart/form-data")]
        [Route("Register")]
        public async Task<IActionResult> Register([FromForm] UserDto userDTO)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };

                return await _Patient.ADD_USER(userDTO, UserRole.Patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the Doctor: {ex.Message}");
            }
        }

        [HttpPost("SignIn")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> SignIn([FromForm] SignInDto UserDto) {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };

                return await _Patient.SignInUser(UserDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Signing In: {ex.Message}");
            }

        }

        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _Patient.LogOut();
            return Ok("LogOut Successfully");
        }
    }
}
