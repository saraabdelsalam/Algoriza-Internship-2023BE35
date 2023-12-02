using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Models
{
    public class Times
    { public int id {  get; set; }
       public DateTime? time { get; set; }
        public Appointment Appointment { get; set; }

    }
}
