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



        public IActionResult GetPatientRequests(string PatientId)
        {
            try
            {
                var Requests = Context.Set<Request>().Where(r => r.PatientId == PatientId);
                var Requests_Appointment = Requests.Join(
                    Context.Set<Times>(),
                    r=>r.TimeId,
                    t=>t.id,
                    (r,t)=> new
                    {
                        r.DoctorId,
                        r.Status,
                        r.DiscountCodeId,
                       Time= t.time.ToString(),
                       t.AppointmentId,
                    }
                    
                    ).Join(
                    Context.Set<Appointment>(),
                    r=>r.AppointmentId,
                    a=>a.id,
                    (r,a)=> new
                    {
                        r.DoctorId,
                        r.Status,
                        r.DiscountCodeId,
                        r.Time,
                       Day= a.day.ToString(),

                    }
                    );

                var Requests_Discount = Requests_Appointment.GroupJoin(
                                            Context.Set<DiscountCode>(),
                                           request => request.DiscountCodeId,
                                            coupon => coupon.id,
                                            (request, coupon) => new
                                            {
                                               request,
                                                coupon
                                            }).SelectMany(
                                                coupon => coupon.coupon.DefaultIfEmpty(),
                                                (r, c) => new
                                                {
                                                    r.request.DoctorId,
                                                    r.request.Status,
                                                    r.request.Day,
                                                    r.request.Time,
                                                    DiscountType = (c == null) ? 0 : c.discountType,
                                                    Value = (c == null) ? 0 : c.value,
                                                    Name = (c == null) ? "No Discount" : c.code
                                                }
                                            );

                var Requests_Doctor = Requests_Discount.Join(
                    Context.Set<Doctor>(),
                    r=>r.DoctorId,
                    d=>d.id,
                    (r,d)=> new PatientRequestsDto
                    { 
                    ImagePath = d.User.Image,
                    DoctorName =d.User.FullName,
                    SpecializationName =d.Specialization.SpecializationName,
                    price =d.Price??0,
                    Day = r.Day,
                    Time =r.Time,
                    RequestStatus = r.Status.ToString(),
                    discoundCodeName =r.Name,
                    DiscountType =r.DiscountType,
                    discoundValue =r.Value
                    
                    });

         
                return new OkObjectResult(Requests_Doctor.ToList());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message + ex.InnerException.ToString);
            }


        }


    }
}
