using Core_Layer.Models;
using Microsoft.AspNetCore.Identity;
using Repository_Layer.Generic_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
    public interface IAppUserRepository: IBaseRepository<ApplicationUser>
    {
        public Task<IdentityResult> AddUser(ApplicationUser user);
      
        public  Task AssignRole(ApplicationUser user, string role);
        public Task AddSignInCookie(ApplicationUser user, bool rememberMe);
        public Task DeleteUser(ApplicationUser user);
    }
}
