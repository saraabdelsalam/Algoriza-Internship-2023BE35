using Core_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Generic_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Repository
{
   public interface ISpecializationRepo: IBaseRepository<Specialization>
    {
        Specialization GetSpecialization(string name);
        IActionResult Top5Sepecializations();
    }
}
