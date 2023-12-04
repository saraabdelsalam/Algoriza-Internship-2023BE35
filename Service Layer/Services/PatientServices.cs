using AutoMapper;
using Core_Layer.Services;
using Microsoft.EntityFrameworkCore.Metadata;
using Service_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class PatientServices:AppUserServices, IPatientServices
    {
        public PatientServices(IUnitOfWork unitOfWork, IMapper mapper ):base(unitOfWork, mapper) { }
    }
}
