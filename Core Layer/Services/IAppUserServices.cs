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
        public Task<IActionResult> ADD_USER(UserDto userDto, UserRole userRole);
      
    }
}
