using FluentValidation.AspNetCore;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Vezeeta.Domain.Contracts;
using FluentValidation;
using Vezeeta.Infrastructure.Repositories;
using Vezeeta.Domain.Entities;
using Vezeeta.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Vezeeta.Application;

public static class ApplicationExtension
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


        services.AddTransient<IDiscountCodeRepository, DiscountCodeRepository>();
        services.AddTransient<IAppUserRepository, ApplicationUserRepository>();
        services.AddTransient<IPatientRepository,PatientRepository>();
        services.AddTransient<IDoctorRepository, DoctorRepository>();
        return services;
    }
}
