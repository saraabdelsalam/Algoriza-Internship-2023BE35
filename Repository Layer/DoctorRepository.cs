using Core_Layer.Models;
using Core_Layer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
 public class DoctorRepository: CRUD<Doctor>, IDoctorRepository
    {
        private UserManager<ApplicationUser> _userManager;

        public DoctorRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> GetDoctorUser(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            Doctor doc = GetById(userId);
            if (doc.id == user.Id)
            {
                return new OkObjectResult(doc);
            }
            return new BadRequestObjectResult("user id not found");
            
        }


        public IActionResult Top10Doctors()
        {
            var Top10 = Context.Set<Request>().GroupBy(r => r.DoctorId).Select(
                requestGrouping => new
                {
                    DoctorId = requestGrouping.Key,
                    RequestsNum = requestGrouping.Count(),
                }
                 ).OrderByDescending(grouping => grouping.RequestsNum).Take(10).
                 Join(Context.Set<Doctor>(),
                 doc => doc.DoctorId,
                 doct => doct.id,
                (doc, doct) => new
                {
                    userId = doct.id,
                    RequestsNum = doc.RequestsNum,
                }).Join(Context.Set<ApplicationUser>(),
                 doc => doc.userId,
                 user => user.Id,
                (doc, user) => new
                {
                    DoctorName = user.FullName,
                    RequestsNum = doc.RequestsNum,
                }).ToList();
            return new OkObjectResult(Top10);

        }
    }
}
