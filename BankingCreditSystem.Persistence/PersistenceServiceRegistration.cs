using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BankingCreditSystem.Persistence.Repositories;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Persistence.Contexts;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<BaseDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        // Repositories
        services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
        services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
        services.AddScoped<ICreditTypeRepository, CreditTypeRepository>();
        services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();

        return services;
    }
}