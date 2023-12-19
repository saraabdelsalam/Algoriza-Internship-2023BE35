using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System.Reflection;

using Vezeeta.Domain.Entities;

namespace Vezeeta.Infrastructure.Data;

public sealed class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Times> Times { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<DiscountCode> DiscountCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        SpecializationsDataSeeding(modelBuilder);
        RolesDataSeeding(modelBuilder);
    }

    private void SpecializationsDataSeeding(ModelBuilder builder)
    {

        builder.Entity<Specialization>()
       .HasData(new List<Specialization>
          {
                    new Specialization
                    {   ID = 1,
                        SpecializationName="Dermatology"
                    },
                    new Specialization
                    {
                        ID = 2,
                        SpecializationName="Dentistry"
                    },
                    new Specialization
                    {
                        ID = 3,
                       SpecializationName ="Nutrition"
                    },
                new Specialization
                    {
                       ID = 4,
                       SpecializationName ="Pediatrics"
                    },
                     new Specialization
                    {
                       ID = 5,
                       SpecializationName ="Psychiatry"
                    },
                 new Specialization
                            {
                                ID = 6,
                                SpecializationName="Ear, Nose and Throat"
                            },
                 new Specialization
                            {
                                ID=7,
                                SpecializationName="Orthopedics(Bones)"
                            },
       });
    }
    private void RolesDataSeeding(ModelBuilder builder)
    {

        // Roles & Admin seeding
        string adminRoleId = "e014c5f9-775e-4112-bbc9-5a6859f60a6a";
        string patientRoleId = "35ea9a1d-a34c-458d-a7cb-4fe2d240d95a";
        string doctorRoleId = "63d379ae-8133-4256-b413-20b3a402dc8c";

        builder.Entity<IdentityRole>()
          .HasData(new List<IdentityRole>
           {
                   new IdentityRole{Id= adminRoleId ,Name = "Admin" , NormalizedName="ADMIN", ConcurrencyStamp="f53984fe-91f6-4f26-af37-20ff3832896a"},
                    new IdentityRole{Id= doctorRoleId,Name = "Doctor", NormalizedName = "DOCTOR", ConcurrencyStamp="191cfa43-3537-4dab-97d9-b0a6c2735491"},
                    new IdentityRole{Id= patientRoleId,Name = "Patient", NormalizedName = "PATIENT", ConcurrencyStamp="bb800914-b683-4ddb-8b55-be1a342074d8"},
           });

        //seeding roles
        string adminId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";

        var appUser = new ApplicationUser
        {
            Id = adminId,
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



        builder.Entity<ApplicationUser>().HasData(appUser);
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = adminRoleId,
            UserId = adminId
        });

    }
}
