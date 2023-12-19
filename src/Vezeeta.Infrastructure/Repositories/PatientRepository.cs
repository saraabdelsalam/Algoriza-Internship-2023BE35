
using Microsoft.AspNetCore.Identity;

using Vezeeta.Domain.Contracts;
using Vezeeta.Domain.Entities;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Infrastructure.Repositories
{
    public class PatientRepository : ApplicationUserRepository, IPatientRepository
    {
        public PatientRepository(AppDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager) :
           base(context, userManager, roleManager, signInManager)
        { }
      


    }
}
