using Core_Layer.DTOs;
using Core_Layer.Enums;
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
     public class PatientRepository:AppUserRepository, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context,UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager) :
           base(context, userManager, roleManager, signInManager)
        { }
        public async Task<IActionResult> GetAllPatients(int Page, int PageSize, Func<PatientInfoDto, bool> criteria = null)
        {
            // Get All patients
            try
            {
                // Get patients
                var patients = (await _userManager.
                         GetUsersInRoleAsync(Enum.GetName(UserRole.Patient))).AsEnumerable();

                IEnumerable<PatientInfoDto> PatientsResult = patients.Select(p => new PatientInfoDto
                {
                    ImagePath = p.Image,
                    PatientName = p.FullName,
                    PatientEmail = p.Email,
                    PatientPhone = p.PhoneNumber,
                    PatientGender = p.Gender.ToString(),
                });

                // Apply Search & Pagination 
                if (criteria != null)
                {
                    PatientsResult = PatientsResult.Where(criteria);
                }

             
                if (Page != 0)
                    PatientsResult = PatientsResult.Skip((Page - 1) * PageSize);

                if (PageSize != 0)
                    PatientsResult = PatientsResult.Take(PageSize);

                return new OkObjectResult(PatientsResult.ToList());
            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem during getting the data {ex.Message}");
            }

        }


    }
}
