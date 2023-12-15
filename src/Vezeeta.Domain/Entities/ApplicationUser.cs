using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Domain.Enums;

namespace Vezeeta.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Image { get; set; }

 
        public string FullName { get; set; }

      
        public Gender Gender { get; set; }

      
        public DateTime DateOfBirth { get; set; }


    }
}
