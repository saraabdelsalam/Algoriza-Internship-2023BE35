using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Models
{
    public class Specialization
    {
        public int id { get; set; }

        [Required]
        public string SpecializationName { get; set; }
        
        //[NotMapped]
        //public int NumOfRequests => Doctors.Sum(x => x.NumOfRequests);
        public List<Doctor>? Doctors { get; set; }
    }
}
