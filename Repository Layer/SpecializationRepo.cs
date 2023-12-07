using Core_Layer.Models;
using Core_Layer.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Top5Sepecializations()
        {
            var Top = Context.Set<Request>().Join(
                Context.Set<Doctor>(),
                 req => req.DoctorId,
                 doct => doct.id,
                (req, doct) => new
                {
                  Specialization = doct.Specialization.SpecializationName,
                }).GroupBy(s=> s.Specialization).Select(


                s => new
                {
                    SpecializationName = s.Key,
                    NumberOfRequests = s.Count(),

                }).Take(5).ToList();
            return new OkObjectResult(Top);
        }
    }

   
}
