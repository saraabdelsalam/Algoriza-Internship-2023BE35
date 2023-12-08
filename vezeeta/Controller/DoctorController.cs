using Core_Layer.DTOs;
using Core_Layer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service_Layer.Services;
using System.Drawing.Printing;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace vezeeta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorServices _doctor;
        private readonly IAppointmentServices _appointmentServices;
        private readonly ITimesServices _timesServices;

        public DoctorController(IDoctorServices Doctor, IAppointmentServices appointmentServices, ITimesServices timesServices)
        {
            _doctor = Doctor;
            _appointmentServices = appointmentServices;
            _timesServices = timesServices;
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

        [HttpPost("Set Price")]

        public async Task<IActionResult> SetPrice(int price)
        {

            if (price <= 0)
            {
                return BadRequest("Price is required");

            }
            string? doctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (doctorId is null)
            {
                return NotFound("User Should Login First");
            }

            return await _doctor.AddPrice(doctorId, price);


        }


        [HttpPost("Appointments")]
      
        public async Task<IActionResult> AddAppointments(AppointmentDto appointments)
        {
        

           
            if (appointments == null)
            {
                return BadRequest("Price and appointment are required");

            }
            if (appointments.Days == null)
            {
                return BadRequest("Appointments is required");
            }

            string? doctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
            if(doctorId is null)
            {
                return BadRequest("Login First ");
            }

            return await _doctor.AddAppointments(doctorId, appointments);
            
          
        }


        [HttpPatch("Appointments")]

        public async Task<IActionResult> UpdateAppointments(int Id, string timeValue )
        {
               if (Id == 0)
            {
                return BadRequest("Invalid Id");

            }
            if (timeValue is null)
            {
                return BadRequest("Invalid time");
            }
            return await _timesServices.EditAppointment(Id, timeValue);

        }
        [HttpDelete("Appointments")]

        public async Task<IActionResult> DeleteAppointments(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("Invalid Id");

            }
          
            return await _timesServices.DeleteAppointment(Id);

        }

        [HttpPatch("Confirm Booking")]
        public async Task<IActionResult> ConfirmBooking(int BookingId)
        {
            if (BookingId == 0)
            {
                return BadRequest("Invalid Id");

            }

            return await _doctor.ConfirmRequest(BookingId);

        }

        [HttpGet("Requests")]
        public IActionResult GetRequests(int PageNumber, int PageSize, string? search) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string? DoctorId = User.Claims.FirstOrDefault(d => d.Type == ClaimTypes.NameIdentifier)?.Value;
            return _doctor.GetDoctorsRequests(DoctorId, PageNumber, PageSize, search);
        }

    }
}
