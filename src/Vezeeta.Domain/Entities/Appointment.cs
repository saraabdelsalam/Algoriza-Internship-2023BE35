using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Domain.Common;
using Vezeeta.Domain.Enums;

namespace Vezeeta.Domain.Entities
{
    public class Appointment: BaseEntity<int>
    {
     
        public WeekDays day { get; set; }
        public List<Times>? times { get; set; }
   

        public Doctor Doctor { get; set; }

    }
}
