using Core_Layer.DTOs;
using Core_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Repository
{
    public interface IRequestRepository : ICommonFunctions<Request>
    {
        int TotalNumOfRequests();
        int TotalNumOfRequests(Expression<Func<Request, bool>> condition);

        IActionResult DoctorsRequests(string DoctorId, int PageSize, int PageNumber,
              Func<DoctorsRequestsDto, bool> condition);
        IActionResult GetPatientRequests(string PatientId);
    }
}
