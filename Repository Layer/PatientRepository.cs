using Core_Layer.Models;
using Core_Layer.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
     public class PatientRepository:AppUserRepository, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context,UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager) :
           base(context, userManager, roleManager, signInManager)
        { }
    }
}
