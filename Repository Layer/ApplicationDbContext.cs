﻿using Core_Layer.Models;
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
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Doctor>().ToTable("Doctors").HasAnnotation("MyCustomAnnotation", "SomeValue");
            builder.Entity<Doctor>().Property(p => p.Price).HasDefaultValue(0);
            #region
            //assigning request relations with restriction on delete option
            builder.Entity<Request>().HasOne<Times>().WithMany()
                .HasForeignKey(r => r.TimeId).OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Requests_Times_TimeId");

            builder.Entity<Request>().HasOne<Doctor>().WithMany()
                .HasForeignKey(r => r.DoctorId).OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Requests_Doctors_DoctorId");

            builder.Entity<Request>().HasOne<ApplicationUser>().WithMany()
                .HasForeignKey(r => r.PatientId).OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Requests_AspNetUsers_PatientId");

            builder.Entity<Request>().HasOne<DiscountCode>().WithMany()
                .HasForeignKey(r => r.DiscountCodeId).OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Requests_discountCodes_DiscountCodeId");

            builder.Entity<Appointment>().HasOne<Doctor>().WithMany()
                 .HasForeignKey(r => r.doctorId).OnDelete(DeleteBehavior.Cascade).
                 HasConstraintName("FK_Appointments_Doctors_DoctorId");
            #endregion
            #region Data Seeding
            // specialization seeding
            builder.Entity<Specialization>()
           .HasData(new List<Specialization>
              {
                    new Specialization
                    { id=1,
                        SpecializationName="Dermatology"
                    },
                    new Specialization
                    {
                        id=2,
                        SpecializationName="Dentistry"
                    },
                    new Specialization
                    {
                        id=3,
                       SpecializationName ="Nutrition"
                    },
                new Specialization
                    {
                        id=4,
                       SpecializationName ="Pediatrics"
                    },
                     new Specialization
                    {
                        id=5,
                       SpecializationName ="Psychiatry"
                    },
                 new Specialization
                            {
                                id =  6,
                                SpecializationName="Ear, Nose and Throat"
                            },
                 new Specialization
                            {
                                id =  7,
                                SpecializationName="Orthopedics(Bones)"
                            },
           });


            // Roles & Admin seeding
            string ROLE_ID = "e014c5f9-775e-4112-bbc9-5a6859f60a6a";
            string ROLE_PATIENT_ID = "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a";
            string ROLE_DOCTOR_ID = "63d379ae-8133-4256-b413-20b3a402dc8c";

            builder.Entity<IdentityRole>()
              .HasData(new List<IdentityRole>
               {
                   new IdentityRole{Id= ROLE_ID ,Name = "Admin" , NormalizedName="ADMIN", ConcurrencyStamp="f53984fe-91f6-4f26-af37-20ff3832896a"},
                    new IdentityRole{Id= ROLE_DOCTOR_ID,Name = "Doctor", NormalizedName = "DOCTOR", ConcurrencyStamp="191cfa43-3537-4dab-97d9-b0a6c2735491"},
                    new IdentityRole{Id= ROLE_PATIENT_ID,Name = "Patient", NormalizedName = "PATIENT", ConcurrencyStamp="bb800914-b683-4ddb-8b55-be1a342074d8"},
               });
            //seeding roles
            string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";

            var appuser = new ApplicationUser
            {
                Id = ADMIN_ID,
                Email = "admin@vezeeta.com",
                NormalizedEmail = "ADMIN@VEZEETA.COM",
                EmailConfirmed = true,
                PhoneNumber = "01021122226",
                FullName = "sara abdelsalam",
                UserName = "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                NormalizedUserName = "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "1234"),
                ConcurrencyStamp = "ed0d2d46-78a9-4e58-a832-d850b5a72c3e",
                SecurityStamp = "c15a3122-22ee-402f-8c72-6c52fb49995f",
                DateOfBirth = new DateTime(2001, 6, 4),
            };



            builder.Entity<ApplicationUser>().HasData(appuser);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            #endregion

        }





        DbSet<Doctor> doctors { get; set; }
        DbSet<Specialization> specializations { get; set; }
        DbSet<Times> times { get; set; }
        DbSet<Appointment> Appointments { get; set; }
        DbSet<Request> Requests { get; set; }
        DbSet<DiscountCode> discountCodes { get; set; }




    }
}
