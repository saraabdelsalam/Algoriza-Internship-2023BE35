using Core_Layer.Enums;
using Core_Layer.Models;
using Core_Layer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
    public class AppointmentRepository: CommonFunctions<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context):base(context) { }

        public Appointment GetByDoctorIdAndDay(string docId, WeekDays day)
        {
           return Context.Set<Appointment>().FirstOrDefault(a => a.doctorId == docId && a.day == day);
        }
    }
}
