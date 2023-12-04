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
    public class SpecializationRepo: BaseRepository<Specialization>, ISpecializationRepo
    {
        public SpecializationRepo(ApplicationDbContext context) : base(context)
        {
        }

        public Specialization GetSpecialization(string name)
        {
            return Context.Set<Specialization>().FirstOrDefault(s=> s.SpecializationName==name);
        }
    }

   
}
