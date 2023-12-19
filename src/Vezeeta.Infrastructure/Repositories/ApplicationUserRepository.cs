

using Microsoft.AspNetCore.Identity;

using Vezeeta.Domain.Contracts;
using Vezeeta.Domain.Entities;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Infrastructure.Repositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IAppUserRepository
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly SignInManager<ApplicationUser> _signInManager;
        public ApplicationUserRepository(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager) : base(context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> AddUser(ApplicationUser user)
        {
            return await _userManager.CreateAsync(user);

        }

        public async Task AddSignInCookie(ApplicationUser user, bool rememberMe)
        {
            await _signInManager.SignInAsync(user, rememberMe);
        }
        public async Task AssignRole(ApplicationUser user, string role)
        {


            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<ApplicationUser> GetUserByID(string id)
        {
            return await _userManager.FindByIdAsync(id);

        }

 

    }
}
