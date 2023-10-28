using ComputerRepair.Application.Common.Interfaces.Autorization;
using ComputerRepair.Application.Common.Interfaces.Email;
using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Infrastructure.Authorization;
using ComputerRepair.Infrastructure.Authorization.Options;
using ComputerRepair.Infrastructure.Email;
using ComputerRepair.Infrastructure.Email.Options;
using ComputerRepair.Infrastructure.Persistence;
using ComputerRepair.Infrastructure.Persistence.CustomIdentityEntity;
using ComputerRepair.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data;

namespace ComputerRepair.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddEmailSender(configuration);
        services.AddAuth(configuration);
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

        services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddTransient<IOfficeRepository, OfficeRepository>();
        services.AddTransient<IRepairTypeRepository, RepairTypeRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection AddEmailSender(this IServiceCollection services, IConfiguration configuration)
    {
        var emailOptions = new EmailOptions();
        configuration.Bind(EmailOptions.SectionName, emailOptions);
        services.AddSingleton(Options.Create(emailOptions));
        services.AddSingleton<IEmailSender, EmailSender>();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = new JwtOptions();
        configuration.Bind(EmailOptions.SectionName, jwtOptions);
        services.AddSingleton(Options.Create(jwtOptions));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
