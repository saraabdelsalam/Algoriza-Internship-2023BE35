using Core_Layer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Models
{
   public class Appointment
    {
        public int id {  get; set; }
        [Required(ErrorMessage ="Day is required")]
        [EnumDataType(typeof(Days))]
       public Days day { get; set; }
        public List<Times>? times {  get; set; }

        public Doctor doc {  get; set; }
    }
}
