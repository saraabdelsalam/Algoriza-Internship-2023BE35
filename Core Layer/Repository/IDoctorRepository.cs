using Core_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Repository
{
    public interface IDoctorRepository: ICRUD<Doctor>
    {

        Task<ApplicationUser> GetDoctorUser(string userId);
    }
}
