
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

    DbSet<Doctor> Doctors { get; set; }
    DbSet<Specialization> Specializations { get; set; }
    DbSet<Times> Times { get; set; }
    DbSet<Appointment> Appointments { get; set; }
    DbSet<Request> Requests { get; set; }
    DbSet<DiscountCode> DiscountCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
