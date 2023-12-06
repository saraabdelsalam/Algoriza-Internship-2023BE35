using Core_Layer.DTOs;
using Core_Layer.Enums;
using Core_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Services
{
   public interface IAppUserServices
    {
        public Task<int> NumOfUsers(string userRole);
        public Task<IActionResult> ADD_USER(UserDto userDto, UserRole userRole);
        public Task<IActionResult> SignInUser(SignInDto signInDto);
     
        public Task<IActionResult> GetUserById(string id);
        public Task<IActionResult> LogOut();
        public Task<IActionResult> UpdateUserData(UserDto UserDto);
        public Task<IActionResult> ChangeRequestStatus(int RequestId, RequestStatus status);


    }
}
