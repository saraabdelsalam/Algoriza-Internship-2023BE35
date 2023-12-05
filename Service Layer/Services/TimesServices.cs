using Core_Layer.Models;
using Core_Layer.Services;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class TimesServices : ITimesServices
    {
        private readonly IUnitOfWork unitOfWork;
        public TimesServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        private TimeSpan TotTimeSpan(string Time)
        {
            return Convert.ToDateTime(Time).TimeOfDay; ;
        }
        private IActionResult AddDayTime(int dayId, TimeSpan time)
        {
            Times appointmentTime;
            //check if the time exists previously
            if (dayId > 0)
            {
                appointmentTime = unitOfWork._timesRepository.GetByDayIdAndTime(dayId, time);

                if (appointmentTime != null)
                {
                    return new OkResult();
                }
            }

            appointmentTime = new Times()
            {
                time = time
            };
            return new OkObjectResult(appointmentTime);

        }
        public IActionResult AddDayTimes(int dayId, List<string> times)
        {
            if (times.Count == 0)
            {
                return new BadRequestObjectResult("Times is required");
            }
            IActionResult actionResult;
            List<Times> dayTimes = new List<Times>();
            TimeSpan timeSlot;
            foreach (var time in times)
            {
                timeSlot = TotTimeSpan(time);
                actionResult = AddDayTime(dayId, timeSlot);
                if (actionResult is not OkObjectResult okObject)
                {
                    continue;
                }
                dayTimes.Add(okObject.Value as Times);
            }

            return new OkObjectResult(dayTimes);
        }

        public IActionResult DeleteAppointment(int timeId)
        {
            throw new NotImplementedException();
        }

        public IActionResult EditAppointment(int timeId, string newTime)
        {
            throw new NotImplementedException();
        }
    }
}
