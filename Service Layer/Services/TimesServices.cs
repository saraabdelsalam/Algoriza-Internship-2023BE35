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

        public async Task<IActionResult> DeleteAppointment(int timeId)
        {
            try
            {
                Times appTime = unitOfWork._timesRepository.GetById(timeId);
                if (appTime == null)
                {
                    return new BadRequestObjectResult("this appointment doesn't exist");
                }
                // checking if booked or not (haven't implemented requests yet)

                await unitOfWork._timesRepository.DeleteAsync(appTime);
                await unitOfWork.SaveAsync();
                return new OkObjectResult("Appointment time has been removed successfully");
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
           
        }

        public async Task<IActionResult> EditAppointment(int timeId, string newTime)
        {
            Times appTime = unitOfWork._timesRepository.GetById(timeId);
            if (appTime == null) {
            return new BadRequestObjectResult("this appointment doesn't exist");
            }
            // checking if booked or not (haven't implemented requests yet)

            appTime.time = TotTimeSpan(newTime);

            // check if there is a similar one then delete it
           bool exists = unitOfWork._timesRepository.Exist(t=> t.id== appTime.id && t.time== appTime.time);
            if (exists)
            {
                return new BadRequestObjectResult("the appointment already exists");
            }
           await unitOfWork._timesRepository.UpdateAsync(appTime);
            await unitOfWork.SaveAsync();
            return new OkObjectResult(appTime);
        }
    }
}
