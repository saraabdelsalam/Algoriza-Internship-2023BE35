using Core_Layer.Models;
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
        public Specialization GetSpecialization(string name);
    }
}
