using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Models;
using Core_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace vezeeta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _Patient;
        private readonly IRequestServices _request;
        public PatientController(IPatientServices patient, IRequestServices request) {
            _Patient = patient;
            _request = request;
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


        [HttpPost("Book Appointment")]
        public async Task<IActionResult> BookAppointment(int timeId, string? discountCode)
        {

            if (timeId <= 0)
            {
                ModelState.AddModelError("timeId","Invalid timeId");
            }
            string? patientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(patientId == null)
            {
                return new BadRequestObjectResult("Login First");
            }
            return await _request.AddRequest(patientId, timeId, discountCode);

        }



        [HttpPatch("Cancell Booking")]
        public async Task<IActionResult> CancellBooking(int BookingId)
        {
            if (BookingId == 0)
            {
                return BadRequest("Invalid Id");

            }

            return await _Patient.CancelRequest(BookingId);

        }
    }
}
