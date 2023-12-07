using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces.Admin;
using Service_Layer.Services;
using Service_Layer.Services.Admin;

namespace vezeeta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDoctorSettingController : ControllerBase
    {
        private readonly IDoctorServices _doctor;
        private readonly IAppUserServices _userServices;
        public AdminDoctorSettingController( IDoctorServices doctor, IAppUserServices userServices)
        {
            
            _doctor = doctor;
            _userServices = userServices;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Route("AddDoctor")]
        public async Task<IActionResult> AddDoctor([FromForm] UserDto userDTO, [FromForm] string Specialize)
        {
            try
            {
                if (string.IsNullOrEmpty(Specialize))
                {
                    ModelState.AddModelError("Specialize", "Specialize Is Required");
                }
                if (userDTO.Image == null || userDTO.Image.Length == 0)
                {
                    ModelState.AddModelError("userDTO.Image", "Image Is Required");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };

                return await _doctor.AddDoctor(userDTO, UserRole.Doctor, Specialize);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the Doctor: {ex.Message}");
            }
        }
    


        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateDoctor([FromForm] string id, [FromForm] UserDto userDTO, [FromForm] string Specialize)
        {
            if (string.IsNullOrEmpty(Specialize))
            {
                ModelState.AddModelError("Specialize", "Specialize Is Required");
            }
            //if (userDTO.Image == null || userDTO.Image.Length == 0)
            //{
            //    ModelState.AddModelError("userDTO.Image", "Image Is Required");
            //}

            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError("Id", "Id Is Required");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            return await _doctor.Edit(id, userDTO, Specialize);
        }

        [HttpDelete("delete doctor")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {

            if(string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError("id", "id is required");
            }
            return await _doctor.Delete(id);
        }


        [HttpGet("GetById")]
        
        public IActionResult GetById([FromForm] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError("Id", "Id is required");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _doctor.GetDoctor(id);
        }

    }
}
