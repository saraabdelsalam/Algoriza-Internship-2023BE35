using Core_Layer.DTOs;
using Core_Layer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Services;
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

        public DoctorController(IDoctorServices Doctor, IAppointmentServices appointmentServices)
        {
            _doctor = Doctor;
            _appointmentServices = appointmentServices;
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

            string? doctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; ;

            return await _doctor.AddAppointments(doctorId, appointments);
            
          
        }



        [HttpPost("Set Price")]

        public async Task<IActionResult> SetPrice(int price)
        {

            if (price <=0)
            {
                return BadRequest("Price is required");

            }
            string? doctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(doctorId is null)
            {
                return NotFound("User Should Login First");
            }

            return await _doctor.AddPrice(doctorId,price);


        }



    }
}
