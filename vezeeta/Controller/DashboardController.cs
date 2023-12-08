using Core_Layer.Enums;
using Core_Layer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace vezeeta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DashboardController : ControllerBase
    {
        private readonly IAppUserServices _appUserServices;
        private readonly IRequestServices _requestServices;
        private readonly IDoctorServices _doctorServices;
        public DashboardController(IAppUserServices appUserServices, IRequestServices requestServices,
            IDoctorServices doctorServices) {
        _appUserServices = appUserServices;
            _requestServices = requestServices;
            _doctorServices = doctorServices;
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
        [HttpGet("Top 10 Doctors")]
        public IActionResult GetTopDoctors()
        {
            return _doctorServices.Top10Doctors();
        }

        [HttpGet("Top 5 Specializationss")]
        public IActionResult GetTopSpecializations()
        {
            return _appUserServices.Top5();
        }
    }
}
