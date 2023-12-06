using Core_Layer.Enums;
using Core_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace vezeeta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IAppUserServices _appUserServices;
        private readonly IRequestServices _requestServices;
        public DashboardController(IAppUserServices appUserServices, IRequestServices requestServices) {
        _appUserServices = appUserServices;
            _requestServices = requestServices;
        }

        [HttpGet("TotalNumberOfDoctors")]
        public async Task<IActionResult> GetNumberOfDoctorsAsync()
        {
            string? Role = Enum.GetName(UserRole.Doctor);
            int total = await _appUserServices.NumOfUsers(Role);
            return Ok(total);
        }

        [HttpGet("TotalNumberOfPatients")]
        public async Task<IActionResult> GetNumberOfPatientsAsync()
        {
            string? Role = Enum.GetName(UserRole.Patient);
            int total = await _appUserServices.NumOfUsers(Role);
            return Ok(total);
        }

        [HttpGet("TotalNumberOfRequests")]
        public IActionResult GetNumberOfRequests()
        {
            return _requestServices.NumOfRequests();
        }
    }
}
