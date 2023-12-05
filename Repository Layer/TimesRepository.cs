using Core_Layer.DTOs;
using Core_Layer.Models;
using Core_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
   public class TimesRepository: CRUD<Times>, ITimesRepository
    {
        public TimesRepository(ApplicationDbContext context):base(context) { }

        public Times GetByDayIdAndTime(int dayId, TimeSpan timeSpan)
        {
            return Context.Set<Times>().FirstOrDefault(a => a.AppointmentId == dayId && a.time==timeSpan);
        }
    }
}
