using Core_Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
    public class AppUserRepository : BaseRepository<ApplicationUser>,IAppUserRepository
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly SignInManager<ApplicationUser> _signInManager;
        public AppUserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager):base(context)
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

        public async Task SignIn(ApplicationUser User, bool RememberMe)
        {
            await _signInManager.SignInAsync(User, RememberMe);
        }
        public async Task<bool> CheckPassword(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<int> NumberOfUsersAsync(string UserRole)
        {
            var role = await _roleManager.FindByNameAsync(UserRole);
            var RoleUsers = await _userManager.GetUsersInRoleAsync(role.Name);
            return  RoleUsers.Count();
        }
        public async Task<IActionResult> UpdateUser(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
           
            return result.Succeeded ? new OkResult() : new BadRequestObjectResult(result.Errors);
        }
        public async Task DeleteUser(ApplicationUser user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task<ApplicationUser> FindByEmail(string email)
        {
         return await _userManager.FindByEmailAsync(email);
           
        }
        public async Task<ApplicationUser> GetUserByID(string id)
        {
            return await _userManager.FindByIdAsync(id);

        }

        public async Task<bool> InRole(ApplicationUser user)
        {
            return await _userManager.IsInRoleAsync(user, "Patient");

        }

    }
}
