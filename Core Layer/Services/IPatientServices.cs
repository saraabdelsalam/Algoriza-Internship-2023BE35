using Core_Layer.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Services
{
    public interface IPatientServices: IAppUserServices
    {
        Task<IActionResult> CancelRequest(int RequestId);
        Task<IActionResult> GetAllPatients(int PageNumber, int PageSize, string search);
    }
}
