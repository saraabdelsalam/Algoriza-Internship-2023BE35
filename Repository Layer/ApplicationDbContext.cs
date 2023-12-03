using Core_Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    { 
        public ApplicationDbContext() { }
        public ApplicationDbContext (DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Doctor>().ToTable("Doctors").HasAnnotation("MyCustomAnnotation", "SomeValue");
       
            // specialization seeding
            builder.Entity<Specialization>().HasData(
                new Specialization { id= 1, SpecializationName="Dermatology" },
                 new Specialization { id = 2, SpecializationName = "Dentistry" },
                  new Specialization { id = 3, SpecializationName = "Pediatrics and New Born" },
                   new Specialization { id = 4, SpecializationName = "Nutrtion" }

             
                   
                   );
            //seeding roles
            string admin_id = "1";
            builder.Entity<IdentityRole>().HasData(
                 new List<IdentityRole> {
                     new IdentityRole
            {
                Name = "admin",
                NormalizedName = "admin",
                Id ="1-admin",

            },
            new IdentityRole
            {
                Name = "doctor",
                NormalizedName = "doctor",
                Id ="2-doctor",

            },
              new IdentityRole
            {
                Name = "patient",
                NormalizedName = "patient",
                Id ="3-patient",

            },
                 }
           );


            var appuser = new ApplicationUser
            {
                Id = admin_id,
                Email = "admin@vezeeta.com",
                EmailConfirmed = true,
                PhoneNumber = "01021122226",
                UserName = "sara abdelsalam",
                NormalizedUserName = "sara abdelsalam"
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appuser.PasswordHash = ph.HashPassword(appuser, "1234");

            builder.Entity<ApplicationUser>().HasData(appuser);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1-admin",
                UserId = admin_id
            });




        }




        DbSet<Doctor> doctors {  get; set; }
        DbSet<Specialization> specializations {  get; set; }
        DbSet<Times> times { get; set; }
        DbSet<Appointment> Appointments { get; set; }
        DbSet<Request> Requests { get; set; }
        DbSet<DiscountCode> discountCodes { get; set; }
      
      


    }
}
