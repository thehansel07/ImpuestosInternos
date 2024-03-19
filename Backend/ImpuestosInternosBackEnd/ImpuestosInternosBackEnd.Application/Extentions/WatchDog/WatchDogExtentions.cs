using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WatchDog;
using WatchDog.src.Enums;

namespace ImpuestosInternosBackEnd.Application.Extentions.WatchDog
{
    public static class WatchDogExtentions
    {
        public static IServiceCollection AddWatchDogs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWatchDogServices(options =>
            {
                options.SetExternalDbConnString = configuration.GetConnectionString("ConnectionStringImpuestosInt");
                options.DbDriverOption = WatchDogDbDriverEnum.MSSQL;
                options.IsAutoClear = true;
                options.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Daily;
            });

            return services;
        }
    }
}
