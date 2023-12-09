using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Models;
using Core_Layer.Repository;
using Core_Layer.Services;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;
using Service_Layer.Interfaces.Admin;
using Service_Layer.Services;
using Service_Layer.Services.Admin;
using System.Web.Http;
using Microsoft.AspNetCore.Authorization;
namespace vezeeta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {

        private readonly IDiscountCode _discountCodeServices;
        private readonly IAppUserServices _appUserServices;
        private readonly IPatientServices _petientServices;
        public AdminController(IDiscountCode DiscountCode, IAppUserServices appUserServices, IPatientServices petientServices)
        {
            _discountCodeServices = DiscountCode;
            _appUserServices = appUserServices;
            _petientServices = petientServices;
        }


     
        [Microsoft.AspNetCore.Mvc.HttpPost("AddDiscountCode")]
        
        public async Task<IActionResult> CreateDiscountCode(DiscountCode code)
        {
            if (code == null)
            {
                return BadRequest("the Discount code doesn't exist");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _discountCodeServices.AddDiscountCode(code);
            

            return Ok(code);
        }

       
        [Microsoft.AspNetCore.Mvc.HttpPut("EditDiscountCode")]
     
        public async Task<IActionResult> EditDiscountCode(DiscountCode code)
        {
            if(code == null)
            {
                return BadRequest("the Discount code doesn't exist");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await _discountCodeServices.EditDiscountCode(code);
            return Ok(code);
        }
       
        [Microsoft.AspNetCore.Mvc.HttpDelete]
        [Route("DeleteDiscountCode")]
        public async Task<IActionResult> DeleteDiscountCode(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            await _discountCodeServices.DeleteDiscountCode(id);   
            return Ok();
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPatch]
        [Route("Deactivate")]
        public async Task<IActionResult> DeactivateDiscountCode(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            await _discountCodeServices.ChangeStatus(id);
            return Ok();
        }


        [Microsoft.AspNetCore.Mvc.HttpGet("AllPatients")]
        public async Task<IActionResult> GetAllPatientsAsync( int PageNumber, int PageSize, string? search)
        {

            return await _petientServices.GetAllPatients(PageNumber,PageSize,search);
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("PatientById")]
        public async Task<IActionResult> GetPatientById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BadRequestObjectResult("Id is required");
            }
            return await _petientServices.GetPatientByIdAsync(id);
        }


    }
}
