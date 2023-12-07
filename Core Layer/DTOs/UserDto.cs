using Core_Layer.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core_Layer.DTOs
{
    public class UserDto
    {

      
        public IFormFile? Image { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(".+@.+\\.com", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Phone number is not valid")]
        public string Phone { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
       public bool RememberMe { get; set; }
       

    }
}
