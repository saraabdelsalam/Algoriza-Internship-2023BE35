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
        public DoctorServices(IUnitOfWork unitOfWork, IMapper mapper, IAppointmentServices appointmentServices) : base(unitOfWork, mapper) {
        
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

            _unitOfWork.SaveAsync();
            return new OkObjectResult("Price & Appointments Added Successfully");
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

                // Update User
                var Updates = await UpdateUserData(userDto);

                //User Creation Failed
                if (Updates is not OkObjectResult)
                {
                    return Updates;
                }

                await _unitOfWork._doctorRepository.UpdateAsync(doc);
               await _unitOfWork.SaveAsync();
                return new OkObjectResult(doc);
            }
            else
            {
                return new BadRequestObjectResult("Failed to get the user");
            }






        }
    }
}
