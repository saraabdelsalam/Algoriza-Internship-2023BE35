using Core_Layer.DTOs;
using Core_Layer.Models;
using Core_Layer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
    public class RequestsRepository: CommonFunctions<Request>,IRequestRepository
    {
        public RequestsRepository(ApplicationDbContext context):base(context) { }

        public int TotalNumOfRequests()
        {
            return Context.Set<Request>().Count();
        }

        public int TotalNumOfRequests(Expression<Func<Request, bool>> condition)
        {
            return Context.Set<Request>().Count(condition);
        }

        public IActionResult DoctorsRequests(string DoctorId, int PageSize, int PageNumber,
            Func<DoctorsRequestsDto, bool> condition)
        {

            try {
            var DoctorRequests = Context.Set<Request>().Where(r=>r.DoctorId==DoctorId);
                var Requests = DoctorRequests.Join(
                    Context.Set<ApplicationUser>(),
                    req => req.PatientId,
                    u => u.Id,
                    (req, u) => new
                    {
                        u.Image,
                        u.FullName,
                        u.Email,
                        u.PhoneNumber,
                        u.Gender,
                        req.TimeId,
                    });

                var RequestTimes = Requests.Join(
                    Context.Set<Times>(),
                    req => req.TimeId,
                    t => t.id,
                    (req, t) => new
                    {
                        req.Image,
                        req.FullName,
                        req.Email,
                        req.PhoneNumber,
                        req.Gender,
                        t.AppointmentId,
                        time = t.time.ToString(), });

 IEnumerable < DoctorsRequestsDto > doctorsRequests = RequestTimes.Join(
    Context.Set<Appointment>(),
    req => req.AppointmentId,
    a=> a.id,
    (req,a)=> new DoctorsRequestsDto
    {
        patientInfo = new PatientInfoDto{
        ImagePath =req.Image,
        PatientName = req.FullName,
        PatientEmail = req.Email,
        PatientPhone = req.PhoneNumber,
        PatientGender = req.Gender.ToString(),
        },
         
        Day = a.day.ToString(),
        time = req.time,
    });

                if(condition != null)
                {
                    doctorsRequests = doctorsRequests.Where(condition);
                }
                if(PageNumber != 0)
                {
                    doctorsRequests = doctorsRequests.Skip((PageNumber - 1) * PageSize);
                }
                if(PageSize!= 0)
                {
                    doctorsRequests = doctorsRequests.Take(PageSize);
                }

                return new OkObjectResult(doctorsRequests.ToList());
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult(ex.Message + ex.InnerException.Message);
            }
        }
    }
}
