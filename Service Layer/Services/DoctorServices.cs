using AutoMapper;
using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Models;
using Core_Layer.Services;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer;
using Service_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class DoctorServices : AppUserServices, IDoctorServices
    {
        private readonly IAppointmentServices _appiontmentServices;
        public DoctorServices(IUnitOfWork unitOfWork, IMapper mapper, IAppointmentServices appointmentServices) :
            base(unitOfWork, mapper) {
        
        _appiontmentServices = appointmentServices;
        }
        public async Task<IActionResult> AddDoctor(UserDto userDTO, UserRole DoctorRole, string specialize)
        {
            // get specialization by name
            Specialization specialization = _unitOfWork._specializationRepo.GetSpecialization(specialize);
            if (specialization == null)
            {
                return new BadRequestObjectResult($" Specialization {specialize} Does not exist");
            }

            var newUser = await ADD_USER(userDTO, UserRole.Doctor);
            //User Creation Failed
            if (newUser is not OkObjectResult okResult)
            {
                return newUser;
            }
            ApplicationUser User = okResult.Value as ApplicationUser;
            Doctor doctor = new()
            {
                id = User.Id,

                User = User,
                Specialization = specialization,
            };
            try
            {
                await _unitOfWork._doctorRepository.AddAsync(doctor);
                await _unitOfWork.SaveAsync();
                return new OkObjectResult(doctor);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Adding Doctor \n: {ex.Message}")
                {
                    StatusCode = 500
                };
            }

        }

        public async Task<IActionResult> AddPrice(string doctorId, int price)
        {
            IActionResult result = await _unitOfWork._doctorRepository.GetDoctorUser(doctorId);

            if (result is OkObjectResult okObjectResult)
            {
                Doctor doc = okObjectResult.Value as Doctor;

                doc.Price = price;
                await _unitOfWork._doctorRepository.UpdateAsync(doc);
                await _unitOfWork.SaveAsync();
                return new ObjectResult(doc.Price);
            }

            return new BadRequestObjectResult("Doctor not found");


        }
        public async Task<IActionResult> AddAppointments(string DoctorId, AppointmentDto appointments)
        {

            // set Days
            var DayOfWeekResult =await _appiontmentServices.AddAppointmentDaysAsync(DoctorId, appointments.Days);
            if (DayOfWeekResult is not OkResult)
            {
                return DayOfWeekResult;
            }

            await _unitOfWork.SaveAsync();
            return new OkObjectResult("Price & Appointments Added Successfully");
        }
        public async Task<IActionResult> ConfirmRequest(int RequestId)
        {
            return await ChangeRequestStatus(RequestId, RequestStatus.Completed);
        }
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                ApplicationUser docUser = _unitOfWork._userRepository.GetById(id);
                if (docUser == null)
                {
                    return new NotFoundObjectResult("Doctor doesn't exist");
                }
                bool hasRequests = _unitOfWork._requestRepository.Exist(r => r.DoctorId == id);
                if (hasRequests)
                {
                    return new BadRequestObjectResult("doctor can't be deleted");
                }


                await _unitOfWork._userRepository.DeleteUser(docUser);
                //await _unitOfWork._doctorRepository.DeleteAsync(doc);
                await _unitOfWork.SaveAsync();

                return new OkResult();
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult(ex.Message + ex.InnerException.Message);
            }







        }
        public async Task<IActionResult> Edit(string id, UserDto userDto, string Specialize)
        {
            IActionResult result = await _unitOfWork._doctorRepository.GetDoctorUser(id);

            if (result is OkObjectResult okObjectResult)
            {
                Doctor doc = okObjectResult.Value as Doctor;

                Specialization specialization = _unitOfWork._specializationRepo.GetSpecialization(Specialize);
                if (specialization == null)
                {
                    return new NotFoundObjectResult("Specialization not found");
                }
                doc.Specialization = specialization;

                ApplicationUser DoctorUser = _unitOfWork._userRepository.GetById(id);
                IActionResult updatesResult =await  Update_User(userDto, DoctorUser);
                await _unitOfWork._doctorRepository.UpdateAsync(doc);
                await _unitOfWork.SaveAsync();
                return new OkObjectResult(updatesResult);
            }
            else
            {
                return new BadRequestObjectResult("failed to get the user");
            }

        }

        public IActionResult Top10Doctors()
        {
            return _unitOfWork._doctorRepository.Top10Doctors();

        }

        public IActionResult GetDoctor(string id)
        {
           try {
                bool exists = _unitOfWork._doctorRepository.Exist(d => d.id == id);
            

                if (!exists)
                {
                    return new NotFoundObjectResult("doctor doesn't exist");
                }
                var Info = _unitOfWork._doctorRepository.GetDoctorById(id);
                if (Info is not OkObjectResult okResult)
                {
                    return Info;
                }


              DoctorInfoDto doctorInfo = okResult.Value as DoctorInfoDto;

                doctorInfo.Image = GetImage(doctorInfo.ImagePath);
                var AllInfo = new
                {
                    doctorInfo.Image,
                    doctorInfo.FullName,
                    doctorInfo.Email,
                    doctorInfo.PhoneNumber,
                    doctorInfo.Gender,
                    doctorInfo.Specialization
                };

                return new OkObjectResult(AllInfo);


            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message + ex.InnerException.Message);
            }


        }
        public IActionResult GetAllDoctors(int PageSize, int PageNumber, String search)
        {
            try {
                Func<DoctorInfoDto, bool> predicate = null;

                if (!string.IsNullOrEmpty(search))
                    predicate = (d=> d.FullName.Contains(search) || d.Email.Contains(search));

               
                var Doctors = _unitOfWork._doctorRepository.GetAllDoctors(PageSize,PageNumber, predicate);
                if (Doctors is not OkObjectResult okResult)
                {
                    return Doctors;
                }
                List<DoctorInfoDto> Alldoctors = okResult.Value as List<DoctorInfoDto>;

                // Load doctor images
                var AllDoctorsInfo = Alldoctors.Select(d => new
                {
                    Image = GetImage(d.ImagePath),
                    FullName = d.FullName,
                    Phone = d.PhoneNumber,
                    Email = d.Email,
                    Gender = d.Gender,
                    Specialization = d.Specialization
                }).ToList();

                return new OkObjectResult(AllDoctorsInfo);



            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message + ex.InnerException.Message);
            }
        }
        public IActionResult GetDoctorsRequests(string doctorId, int PageNum, int PageSize, string search)
        {
            try {
                Func<DoctorsRequestsDto, bool> condition = null;
                if (string.IsNullOrEmpty(search))
                {
                    condition = (c=> c.patientInfo.PatientName.Contains(search) ||c.patientInfo.PatientEmail.Contains(search));

                }
                var Result = _unitOfWork._requestRepository.DoctorsRequests(doctorId,PageSize,PageNum,condition);
                 if( Result is not OkObjectResult res)
                {
                    return  Result;
                }
                List<DoctorsRequestsDto> RequestsList = res.Value as List<DoctorsRequestsDto>;

                if (RequestsList == null || RequestsList.Count == 0)
                {
                    return new NotFoundObjectResult("There is no bookings");
                }
                
                var doctorsRequests = RequestsList.Select(r => new
                {
                    Image = GetImage(r.patientInfo.ImagePath),
                    r.patientInfo.PatientName,
                    r.patientInfo.PatientEmail,
                     r.patientInfo.PatientPhone,
                    r.patientInfo.PatientGender,
                    r.Day,
                    r.time
                }).ToList();

                return new OkObjectResult(doctorsRequests);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message + ex.InnerException.Message);
            }


        }
   
        public IActionResult SearchDoctorsData(int PageNumber, int PageSize, string? search)
        {
            try
            {
                Func<DoctorInfoDto, bool> condition = null;

                if (!string.IsNullOrEmpty(search))
                    condition= (a => a.FullName.Contains(search) || a.Email.Contains(search));

              
                var DoctorsResult = _unitOfWork._doctorRepository.SearchDoctors(PageNumber, PageSize, condition);
                if (DoctorsResult is not OkObjectResult Result)
                {
                    return DoctorsResult;
                }
                List<DoctorInfoDto> ListOfDoctors = Result.Value as List<DoctorInfoDto>;

                // Load doctor images
                var doctorsInfo = ListOfDoctors.Select(d => new
                {
                    Image = GetImage(d.ImagePath),
                    d.FullName,
                    d.Email,
                    d.PhoneNumber,
                    d.Gender,
                    d.Price,
                    d.Specialization,
                    d.Appointments
                }).ToList();

                return new OkObjectResult(doctorsInfo);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting Doctors info \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }




        }
    }
}
