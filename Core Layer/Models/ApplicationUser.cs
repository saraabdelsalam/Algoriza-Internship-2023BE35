using Core_Layer.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Models
{
    public class ApplicationUser:IdentityUser
    {
     
        public string? image { get; set; }

        
        [Required(ErrorMessage ="Gender is required")]
        [EnumDataType(typeof(Gender))]
       public  Gender gender { get; set; }
        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth {  get; set; }
       public List<Request>? requests { get; set; }


    }
}
