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
        //Top Specializations depending on number of requests for doctors in certain specialization
        public IActionResult Top5Sepecializations()
        {
            //Join Requests table with doctors table 
            var Top = Context.Set<Request>().Join(
                Context.Set<Doctor>(),
                 req => req.DoctorId,
                 doct => doct.id,
                (req, doct) => new
                {
                    //accessing the specialization name from the specialization nav property
                  Specialization = doct.Specialization.SpecializationName,
                }).GroupBy(s=> s.Specialization).Select(

                s => new
                {
                    SpecializationName = s.Key,
                    NumberOfRequests = s.Count(),

                }).Take(5).OrderByDescending(s=>s.NumberOfRequests).ToList();
            return new OkObjectResult(Top);
        }
    }

   
}
