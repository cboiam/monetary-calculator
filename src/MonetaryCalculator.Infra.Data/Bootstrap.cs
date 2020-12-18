using Microsoft.Extensions.DependencyInjection;
using ImplementationDiscovery.Extensions;
using MonetaryCalculator.Domain.Employees.Queries;
using MonetaryCalculator.Infra.Data.Repositories;
using MonetaryCalculator.Domain.Employees.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MonetaryCalculator.Infra.Data
{
    public static class Bootstrap
    {
        public static IServiceCollection RegisterDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("default"));
            });

            services.RegisterImplementationsOf(typeof(IMapper<,>)).AsScoped();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IEmployeeQuery, EmployeeRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IWageRepository, WageRepository>();
            services.AddScoped<IVacationRepository, VacationRepository>();

            return services;
        }
    }
}
