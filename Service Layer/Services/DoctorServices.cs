using AutoMapper;
using Core_Layer.DTOs;
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
    public class DoctorServices : AppUserServices, IDoctorServices
    {
        public DoctorServices(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
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

               User =User,
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


        //public Task<IActionResult> Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}
        //public Task<IActionResult> Edit(int id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
