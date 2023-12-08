using Core_Layer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Repository
{
    public interface IPatientRepository:IAppUserRepository
    {
        Task<IActionResult> GetAllPatients(int Page, int PageSize, Func<PatientInfoDto, bool> criteria = null);
    }
}
