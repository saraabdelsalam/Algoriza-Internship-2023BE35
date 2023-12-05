using Core_Layer.DTOs;
using Core_Layer.Enums;
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
    public class AppointmentServices : IAppointmentServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITimesServices timesServices;
        public AppointmentServices(IUnitOfWork unitOfWork, ITimesServices timesServices)
        {
            this.unitOfWork = unitOfWork;
            this.timesServices = timesServices;
        }

        private IActionResult StringToDay(string day)
        {
            DaysOfWeek DayOfWeek;
            if (Enum.TryParse(day, true, out DayOfWeek))
            {
                return new OkObjectResult(DayOfWeek);
            }
            else
            {
                return new BadRequestObjectResult("invalid Day");
            }
        }
        private async Task<IActionResult> AddDay(string doctorId, Days Day)
        {
            if (Day.Times == null)
            {
                return new BadRequestObjectResult("No Time Slots for this day");
            }

            var result = StringToDay(Day.Day);

            if (result is not OkObjectResult okResult)
            {
                return result;
            }
            DaysOfWeek DayOfWeek = (DaysOfWeek)okResult.Value;

            Appointment appointment = unitOfWork._appointmentRepository.GetByDoctorIdAndDay(doctorId, DayOfWeek);
            int DayId = 0;
            if (appointment == null)
            {
                appointment = new Appointment()
                {
                    doctorId = doctorId,
                    day = DayOfWeek,
                };
            }
            else
            {
                DayId = appointment.id;
            }

            IActionResult DayTimesResult = timesServices.AddDayTimes(DayId, Day.Times);
            if (DayTimesResult is not OkObjectResult TimesResult)
            {
                return DayTimesResult;
            }

            var TimesList = (List<Times>)TimesResult.Value;
            if (TimesList.Count == 0)
            {
                return new OkResult();
            }
            appointment.times = TimesList;

            try
            {
                if (DayId == 0)
                {
                   await unitOfWork._appointmentRepository.AddAsync(appointment);
                }
                else
                {
                  await  unitOfWork._appointmentRepository.UpdateAsync(appointment);
                }
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"There is a problem while Adding {Day} \n {ex.Message}" +
                     $"\n {ex.InnerException?.Message}");
            }
        }


        public async Task<IActionResult> AddAppointmentDaysAsync(string doctorId, List<Days> days)
        {
            IActionResult result;
            foreach (var day in days)
            {
                result = await AddDay(doctorId, day);
                if (result is not OkResult)
                {
                    return result;
                }
            }
            return new OkResult();
        }
    }
}
