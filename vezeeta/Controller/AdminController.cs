using Core_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;

namespace vezeeta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseApiController
    {
        public AdminController(IUnitOfWork Adminrepo ,ILogger logger): base(Adminrepo,logger) { 
        }


        [HttpPost]
        public async Task<IActionResult> CreateDiscountCode(DiscountCode code)
        {
            await _unitOfWork.discountCode.AddDiscountCode(code);
            await _unitOfWork.SaveAsync();
            return Ok(code);
        }
    }
}
