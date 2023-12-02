using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Models
{
    public class Doctor: ApplicationUser
    {
        
        public int price { get; set; }

        //Navigation Properties
        public List<Appointment>? appointments { get; set; }
        public Specialization? Specialization { get; set; }
        public List<Request>? Requests { get; set; }



    }
}
