using Core_Layer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Services
{
    public interface IAppointmentServices
    {
        Task<IActionResult> AddAppointmentDaysAsync(string doctorId, List<Days> days);
    }
}
