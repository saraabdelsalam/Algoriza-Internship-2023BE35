using AutoMapper;
using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Services;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> CancelRequest(int id)
        {
            return await ChangeRequestStatus(id, RequestStatus.Cancelled);
        }

        public async Task<IActionResult> GetAllPatients(int PageNumber, int PageSize, string search)
        {

            try
            {
                Func<PatientInfoDto, bool> critertia = null;
                if (!string.IsNullOrEmpty(search))
                {
                    critertia = (p => p.PatientName.Contains(search) || p.PatientEmail.Contains(search));
                }
                var result = await _unitOfWork._patientRepository.GetAllPatients(PageNumber, PageSize, critertia);
                if(result is not OkObjectResult okObjectResult)
                {
                    return result;
                }
                List<PatientInfoDto> PatientsInfo = okObjectResult.Value as List<PatientInfoDto>;

                if (PatientsInfo == null || PatientsInfo.Count() == 0)
                {
                    return new NotFoundObjectResult("There is no patients");
                }

                // Load doctor images
                var Info = PatientsInfo.Select(d => new
                {
                    Image = GetImage(d.ImagePath),
                    d.PatientName,
                    d.PatientEmail,
                    d.PatientPhone,
                    d.PatientGender,
                   
                }).ToList();

                return new OkObjectResult(Info);
            }
            catch (Exception ex) {
                return new BadRequestObjectResult(ex.Message + ex.InnerException.Message);
            }
           

        }
    }
}
