using AutoMapper;
using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Models;
using Core_Layer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class AppUserServices : IAppUserServices
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public AppUserServices(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> ADD_USER(UserDto userDto, UserRole userRole)
        {
            ApplicationUser newUser = _mapper.Map<ApplicationUser>(userDto);
            string? NewUserRole = Enum.GetName(userRole);
            if (NewUserRole == null)
            {
                return new NotFoundObjectResult("Role is not found");
            }

            try
            {
                 
                IdentityResult result = await _unitOfWork._userRepository.AddUser(newUser);
                if (result.Succeeded)
                {
                    await _unitOfWork._userRepository.AssignRole(newUser,NewUserRole);
                    try
                    {
                        await _unitOfWork._userRepository.AddSignInCookie(newUser,userDto.RememberMe);
                    }
                    catch (Exception ex)
                    {
                        await _unitOfWork._userRepository.DeleteUser(newUser);
                        return new ObjectResult($"An error occurred while Creating cookie \n: {ex.Message}")
                        {
                            StatusCode = 500
                        };
                    }
                    return new OkObjectResult(newUser);
                }
                else
                {
                    return new BadRequestResult();
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork._userRepository.DeleteUser(newUser);
                return new BadRequestObjectResult($"{ex.Message}\n {ex.InnerException?.Message}");
            }

        }
      
    }
}


