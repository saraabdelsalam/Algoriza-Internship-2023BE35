﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Services
{
    public interface IRequestServices
    {
        IActionResult NumOfRequests();
        Task<IActionResult> AddRequest(string PatientId, int TimeId, string DiscountCode);
    }
}
