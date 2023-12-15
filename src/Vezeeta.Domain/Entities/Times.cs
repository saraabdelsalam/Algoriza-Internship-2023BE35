using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Domain.Entities
{ 
    public class Times
    {
        public int id { get; set; }
      
        public TimeSpan? time { get; set; }
     
    
        public Appointment Appointment { get; set; }

    }
}
