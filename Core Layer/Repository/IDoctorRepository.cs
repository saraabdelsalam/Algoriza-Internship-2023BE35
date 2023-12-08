using Core_Layer.DTOs;
using Core_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Repository
{
    public interface IDoctorRepository: ICRUD<Doctor>
    {

        Task<IActionResult> GetDoctorUser(string userId);
        IActionResult Top10Doctors();
        IActionResult SearchDoctors(int PageSize, int PageNumber, Func<DoctorInfoDto, bool> predicate);
        IActionResult GetDoctorById(string id);
        IActionResult GetAllDoctors(int pageSize, int pageNumber, Func<DoctorInfoDto, bool> predicate = null);
    }
}
