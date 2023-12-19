
using Microsoft.AspNetCore.Identity;

using Vezeeta.Domain.Entities;

namespace Vezeeta.Domain.Contracts
{
    public interface IAppUserRepository : IBaseRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetUserByID(string id);
        Task<IdentityResult> AddUser(ApplicationUser user);
        Task AssignRole(ApplicationUser user, string role);
        Task AddSignInCookie(ApplicationUser user, bool rememberMe);
        
    }
}
