using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Models;
using Core_Layer.Repository;
using Core_Layer.Services;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;
using Service_Layer.Interfaces.Admin;
using Service_Layer.Services;

using System.Web.Http;
using Microsoft.AspNetCore.Authorization;

namespace vezeeta.Controller.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class DiscountCodeController : ControllerBase
    {

        private readonly IDiscountCode _discountCodeServices;


        public DiscountCodeController(IDiscountCode DiscountCode, IAppUserServices appUserServices, IPatientServices petientServices)
        {
            _discountCodeServices = DiscountCode;


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
            if (code == null)
            {
                return BadRequest("the Discount code doesn't exist");
            }
            if (!ModelState.IsValid)
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
        [Route("Deactivate DiscountCode")]
        public async Task<IActionResult> DeactivateDiscountCode(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            await _discountCodeServices.ChangeStatus(id);
            return Ok();
        }



    }
}
