using Core_Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Generic_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
    public interface IAppUserRepository : IBaseRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetUserByID(string id);
        Task<bool> CheckPassword(ApplicationUser user, string password);
        Task<int> NumberOfUsersAsync(string userRole);
        Task<IdentityResult> AddUser(ApplicationUser user);
        Task<ApplicationUser> FindByEmail(string email);
        Task<bool> InRole(ApplicationUser user);
        Task AssignRole(ApplicationUser user, string role);
        Task AddSignInCookie(ApplicationUser user, bool rememberMe);
        Task SignIn(ApplicationUser User, bool RememberMe);
        Task<IActionResult> UpdateUser(ApplicationUser user);
        Task DeleteUser(ApplicationUser user);
        Task SignOut();
    }
}
