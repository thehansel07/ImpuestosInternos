using ImpuestosInternosBackEnd.Infrastructure.Persistence.Contexts;
using ImpuestosInternosBackEnd.Infrastructure.Persistence.Interfaces;
using ImpuestosInternosBackEnd.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImpuestosInternosBackEnd.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var asembly = typeof(ImpuestoInternosContext).Assembly.FullName;

            services.AddDbContext<ImpuestoInternosContext>(a =>
                                                           a.UseSqlServer(configuration.GetConnectionString("ConnectionStringImpuestosInt"),
                                                           b => b.MigrationsAssembly(asembly)), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
