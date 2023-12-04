using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Models
{
    public class Doctor
    {
       public string id { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public int? Price { get; set; }

        [ForeignKey("FK_Doctors_AspNetUsers_UserId")]
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public Specialization? Specialization { get; set; }
    

    }
}
