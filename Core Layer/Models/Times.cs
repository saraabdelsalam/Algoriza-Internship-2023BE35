using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Models
{
    public class Times
    { public int id {  get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan? time { get; set; }
        [ForeignKey("FK_AppointmentTimes_Appointments_AppointmentId")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

    }
}
