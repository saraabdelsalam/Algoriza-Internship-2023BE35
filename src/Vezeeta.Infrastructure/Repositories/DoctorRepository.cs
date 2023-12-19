

using Microsoft.AspNetCore.Identity;

using Vezeeta.Domain.Contracts;
using Vezeeta.Domain.Entities;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Infrastructure.Repositories
{
    public class DoctorRepository : CRUD<Doctor>, IDoctorRepository
    {
        private UserManager<ApplicationUser> _userManager;

        public DoctorRepository(AppDbContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

       

    }
}
