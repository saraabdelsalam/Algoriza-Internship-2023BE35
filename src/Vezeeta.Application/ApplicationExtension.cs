using FluentValidation.AspNetCore;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Vezeeta.Domain.Contracts;
using FluentValidation;
using Vezeeta.Infrastructure.Repositories;

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

        services.AddTransient<IDiscountCodeRepository, DiscountCodeRepository>();
        return services;
    }
}
