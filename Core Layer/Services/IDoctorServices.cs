﻿using Core_Layer.DTOs;
using Core_Layer.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Services
{
    public interface IDoctorServices: IAppUserServices
    {

        Task<IActionResult> AddDoctor(UserDto userDTO, UserRole doctorRole, string specialization);
        Task<IActionResult> AddPrice(string doctorId, int price);
        Task<IActionResult> AddAppointments(string DoctorId, AppointmentDto appointments);
        //Task<IActionResult> Delete(int id);
        Task<IActionResult> Edit(string id, UserDto userDto, string Specialize);
        public Task<IActionResult> ConfirmRequest(int RequestId);
    }

}
