using Core_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces.Admin;

namespace vezeeta.Controller.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class AdminPatientController : ControllerBase
    {

        private readonly IPatientServices _petientServices;
        public AdminPatientController(IDiscountCode DiscountCode, IAppUserServices appUserServices, IPatientServices petientServices)
        {

            _petientServices = petientServices;
        }




        [HttpGet("AllPatients")]
        public async Task<IActionResult> GetAllPatientsAsync(int PageNumber, int PageSize, string? search)
        {

            return await _petientServices.GetAllPatients(PageNumber, PageSize, search);
        }
        [HttpGet("PatientById")]
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
