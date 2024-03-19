using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using System.Reflection;
using ImpuestosInternosBackEnd.Application.Interfaces;
using ImpuestosInternosBackEnd.Application.Services;
using ImpuestosInternosBackEnd.Application.Extentions.WatchDog;

namespace ImpuestosInternosBackEnd.Application.Extentions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IComprobantesFiscalesApplication, ComprobantesFiscalesApplication>();
            services.AddScoped<IContribuyenteApplication, ContribuyenteApplication>();
            services.AddWatchDogs(configuration);
            return services;
        }
    }
}
