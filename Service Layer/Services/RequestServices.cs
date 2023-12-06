using Core_Layer.Enums;
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
