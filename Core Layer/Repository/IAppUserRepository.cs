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
    public interface IAppUserRepository: IBaseRepository<ApplicationUser>
    {
        public Task<ApplicationUser> GetUserByID(string id);
        public Task<bool> CheckPassword(ApplicationUser user, string password);
        public Task<int> NumberOfUsersAsync(string userRole);
        public Task<IdentityResult> AddUser(ApplicationUser user);
       public Task<ApplicationUser> FindByEmail(string email);
        public  Task AssignRole(ApplicationUser user, string role);
        public Task AddSignInCookie(ApplicationUser user, bool rememberMe);
        public Task SignIn(ApplicationUser User, bool RememberMe);
        public Task<IActionResult> UpdateUser(ApplicationUser user);
        public Task DeleteUser(ApplicationUser user);
        public Task SignOut();
    }
}
