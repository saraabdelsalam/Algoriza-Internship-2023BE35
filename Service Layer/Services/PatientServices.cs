using AutoMapper;
using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Models;
using Core_Layer.Services;
using Microsoft.AspNetCore.Identity;
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
        public async Task<IActionResult> GetPatientByIdAsync(string id)
        {
            try {

              

                ApplicationUser Patient = _unitOfWork._patientRepository.GetById(id);

                if (Patient == null)
                {
                    return new NotFoundResult();
                }
                // Check if the user is in the "patient" role
                if (!await _unitOfWork._patientRepository.InRole(Patient))
                {
                    return new ForbidResult();
                }
              


               
                IActionResult Requests = GetPatientRequests(id);

                object PatientRequests = null;
                if (Requests is OkObjectResult OkObject)
                {
                    PatientRequests = OkObject.Value;
                }

                
                var patientInfo = new
                {
                    Image = GetImage(Patient.Image),
                    Patient.FullName,
                    Patient.Email,
                    Patient.PhoneNumber,
                    Patient.Gender,
                    Patient.DateOfBirth,
                    
                   Requests = PatientRequests
                };

                return new OkObjectResult(patientInfo);


            } catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message + ex.InnerException.Message);
            }
        }

        public IActionResult GetPatientRequests(string PatientId)
        {
            try {

                var result = _unitOfWork._requestRepository.GetPatientRequests(PatientId);
                if(result is not OkObjectResult ok)
                {
                    return result;
                }
                List<PatientRequestsDto> Requests = ok.Value as List<PatientRequestsDto>;
                if (Requests == null || Requests.Count() == 0)
                {
                    return new BadRequestObjectResult(" ther's no appointments booked");
                }
                //load the image and final price
                var PatientRequests = Requests.Select(

                    r => new
                    {
                        Image = GetImage(r.ImagePath),
                        r.DoctorName,
                        r.SpecializationName,
                        r.RequestStatus,
                        r.Day,
                        r.Time,
                        r.discoundCodeName,
                        FinalPrice = FinalPrice(r.price, r.discoundValue, r.DiscountType),
                    }
                    );
                return new OkObjectResult(PatientRequests);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message + ex.InnerException.Message);

            }
        }

        private int FinalPrice(int price, int DiscountValue, DiscountType discountType)
        {
            int Value = 0;

            if (discountType == DiscountType.value)
               Value = DiscountValue;
            else
            {
                Value = (price * DiscountValue) / 100;
            }

            return price - Value;
        }
    }
}
