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
   public class SpecializationServices:ISpecializationServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public SpecializationServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //top specializations 
        public IActionResult Top5()
        {
            return _unitOfWork._specializationRepo.Top5Sepecializations();
        }

    }
}
