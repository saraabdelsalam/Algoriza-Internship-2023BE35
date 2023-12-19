using AutoMapper;
using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Models;
using Core_Layer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;
using System.Drawing;

using Microsoft.EntityFrameworkCore;

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
                    await _unitOfWork._userRepository.AssignRole(newUser, NewUserRole);
                    try
                    {
                        await _unitOfWork._userRepository.AddSignInCookie(newUser, userDto.RememberMe);
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

        public async Task<IActionResult> Update_User(EditDoctorDTo userDto, ApplicationUser user)
        {
            ApplicationUser EditedUser = _mapper.Map<ApplicationUser>(userDto);
            user.FullName = EditedUser.FullName;
            user.PhoneNumber = EditedUser.PhoneNumber;
            user.DateOfBirth = EditedUser.DateOfBirth;
            user.Image = EditedUser.Image;
            user.Gender = EditedUser.Gender;
            try
            {

                IActionResult result = await _unitOfWork._userRepository.UpdateUser(user);
                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency conflict
                // You might choose to reload the entity again, prompt the user, or take another action
                return new BadRequestObjectResult($"Concurrency conflict: {ex.Message}");
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult($"{ex.Message}\n {ex.InnerException?.Message}");
            }

        }

        public async Task<IActionResult> SignInUser(SignInDto signInDto)
        {
            ApplicationUser user = await _unitOfWork._userRepository.FindByEmail(signInDto.Email);
            bool pass = await _unitOfWork._userRepository.CheckPassword(user, signInDto.Password);
            if (user == null || pass == false)
            {
                return new NotFoundResult();
            }

            await _unitOfWork._userRepository.SignIn(user, signInDto.RememberMe);
            return new OkObjectResult(user);
        }
        public async Task<IActionResult> LogOut()
        {
            await _unitOfWork._userRepository.SignOut();
            return new OkResult();
        }

        public async Task<int> NumOfUsers(string userRole)
        {

            return await _unitOfWork._userRepository.NumberOfUsersAsync(userRole);

        }

        public async Task<IActionResult> GetUserById(string id)
        {
            ApplicationUser user = await _unitOfWork._userRepository.GetUserByID(id);
            if (user == null)
            {
                return new NotFoundResult();
            }
            UserDto userDto = _mapper.Map<UserDto>(user);
            return new OkObjectResult(userDto);
        }

        public async Task<IActionResult> UpdateUserData(UserDto UserDto)
        {
            try
            {
                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(UserDto);
                IActionResult updated = await _unitOfWork._userRepository.UpdateUser(applicationUser);

                return updated;

            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult(ex.Message.ToString());
            }




        }

        public async Task<IActionResult> ChangeRequestStatus(int RequestId, RequestStatus status)
        {
            Request request = _unitOfWork._requestRepository.GetById(RequestId);
            if (request == null)
            {
                return new NotFoundResult();
            }
            if (request.Status == RequestStatus.Pending)
            {
                request.Status = status;
                try
                {
                    await _unitOfWork._requestRepository.UpdateAsync(request);
                    await _unitOfWork.SaveAsync();
                    return new OkResult();
                }
                catch
                {
                    return new ObjectResult("couldn't update the status");
                }

            }
            else
            {

                return new ObjectResult("couldn't update the status");
            }


        }

        protected Bitmap GetImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return null;
            }

            return new Bitmap(imagePath);
        }


    }
}


