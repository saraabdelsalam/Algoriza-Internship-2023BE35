using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;

namespace vezeeta.Controller
{
  
    public class BaseApiController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger _logger;
        public BaseApiController(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
    }

}
