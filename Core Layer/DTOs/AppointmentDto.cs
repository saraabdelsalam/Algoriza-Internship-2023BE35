using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.DTOs
{
   public class AppointmentDto
    {
        public int Price {  get; set; }
       public List<Days> Days { get; set; }

    }
    public class Days
    {

        public string Day { get; set; }
        public List<string> Times { get; set; }
    }
}
