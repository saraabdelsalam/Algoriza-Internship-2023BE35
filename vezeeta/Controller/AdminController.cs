using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Models;
using Core_Layer.Repository;
using Core_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;
using Service_Layer.Interfaces.Admin;
using Service_Layer.Services;
using Service_Layer.Services.Admin;

namespace vezeeta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IDiscountCode _discountCodeServices;
        
        public AdminController(IDiscountCode DiscountCode)
        {
            _discountCodeServices = DiscountCode;
            
        }


    
        [HttpPost]
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


        [HttpPut]
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

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCode(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            await _discountCodeServices.DeleteDiscountCode(id);   
            return Ok();
        }

        [HttpPatch]
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
    }
}
