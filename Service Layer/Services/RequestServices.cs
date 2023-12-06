using Core_Layer.Enums;
using Core_Layer.Models;
using Core_Layer.Services;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class RequestServices : IRequestServices
    {
        private readonly IUnitOfWork _unitOfWork;
      public RequestServices(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> AddRequest(string PatientId, int TimeId, string DiscountCode)
        {
            Times RequestTime = GetAppointmentTime(TimeId);
            if(RequestTime == null) {
            return new BadRequestObjectResult("Invalid Time Span");
            }
            if(IsAvailable(TimeId)== false)
            {
                return new BadRequestObjectResult("Appointment is already booked");


            }
            string? DoctorId = GetDoctorId(RequestTime.AppointmentId);
            Request NewRequest = new Request()
            {
        
                DoctorId = DoctorId,
                PatientId = PatientId,
                TimeId = TimeId,
                Status = RequestStatus.Pending,

            };
             if(!string.IsNullOrEmpty(DiscountCode))
            {

                DiscountCode code = _unitOfWork._discountRepository.GetByName(DiscountCode);
                if(code == null) {
                    return new BadRequestResult();
                }
                bool? actived = CheckDiscountCode(code);
                if(actived == null || actived==false) {

                    return new BadRequestObjectResult("Discount code is not activated");
                }
                bool minmumRequests = CheckNumOfRequests(code.RequestsNumber, PatientId);
                if(minmumRequests == false)
                {
                    return new BadRequestObjectResult("Discount code can't be used");
                }
                bool usedBefore = IsUsedBefore(code.id, PatientId);
                if(usedBefore == true) {


                    return new BadRequestObjectResult("you have used this discount code before");
                }
                NewRequest.DiscountCodeId= code.id;
            }
            try
            {
                await _unitOfWork._requestRepository.AddAsync(NewRequest);
               await _unitOfWork.SaveAsync();
                return new OkObjectResult(NewRequest);
            }
            catch(Exception ex) { 
            
                return new BadRequestObjectResult(ex.Message + ex.InnerException.Message);
            }
           
         
        }
        private bool? CheckDiscountCode(DiscountCode discountCode)
        {
            return discountCode.Activated;

        }
        private bool CheckNumOfRequests(int numOfRequests, string patientId)
        {
            int NumberOfRequests = _unitOfWork._requestRepository.TotalNumOfRequests(b => b.PatientId == patientId);
            return NumberOfRequests >= numOfRequests;
        }
        private bool IsUsedBefore(int discountCodeId, string PatientId) {

            bool IsUsedBefore = _unitOfWork._requestRepository.Exist(r => r.DiscountCodeId == discountCodeId
            && r.PatientId == PatientId);
            return IsUsedBefore;
        }
        private string GetDoctorId(int appointmentId)
        {
            Appointment? app = GetAppointment(appointmentId);
            return app.doctorId;

        }
        private bool IsAvailable(int timeId) {
        
         bool Exists =_unitOfWork._requestRepository.Exist(r=>r.TimeId==timeId && r.Status== RequestStatus.Pending);
        return !Exists;
        }
        private Appointment GetAppointment(int AppointmentId) {
        return _unitOfWork._appointmentRepository.GetById(AppointmentId);
        }
        private  Times GetAppointmentTime(int id)
        {
            return _unitOfWork._timesRepository.GetById(id);
        }

     
        public IActionResult NumOfRequests()
        {
            int TotalRequests = _unitOfWork._requestRepository.TotalNumOfRequests();
            int TotalCompletedRequests = _unitOfWork._requestRepository.TotalNumOfRequests(r => r.Status == RequestStatus.Completed);
            int TotalPendingRequests = _unitOfWork._requestRepository.TotalNumOfRequests(r => r.Status == RequestStatus.Pending);
            int TotalCancelledRequests = _unitOfWork._requestRepository.TotalNumOfRequests(r => r.Status == RequestStatus.Cancelled);
            var Total = new 
            {
                totalRequests=TotalRequests,
                totalcompleted=TotalCompletedRequests,
                totalPending=TotalPendingRequests,
                totalCancelled=TotalCancelledRequests,  
            };

            return new OkObjectResult(Total);
        }
        
    }
}
