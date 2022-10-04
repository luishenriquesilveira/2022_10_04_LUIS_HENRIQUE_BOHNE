using RateMyAnimal.Domain.Enum;
using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Domain.Services;
using RateMyAnimal.Infrastructure.ExternalServices;

namespace RateMyAnimal.Application.Configurations
{
    public static class ServiceConfigurationExtension
    {
        public static void AddServicesDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddTransient<ICdnShibeOnlineService, CdnShibeOnlineService>();

            services.AddTransient<CatAsService>();
            services.AddTransient<PlaceDogService>();
            services.AddTransient<ShibeOnlineService>();

            services.AddTransient<Func<ServiceEnum, IRandomAnimalService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case ServiceEnum.CatAs:
                        return serviceProvider.GetService<CatAsService>();
                    case ServiceEnum.PlaceDog:
                        return serviceProvider.GetService<PlaceDogService>();
                    case ServiceEnum.ShibeOnline:
                        return serviceProvider.GetService<ShibeOnlineService>();
                    default:
                        return null;
                }
            });

            #region HttpClient
            services.AddHttpClient<IRandomAnimalService, CatAsService>();
            services.AddHttpClient<IRandomAnimalService, PlaceDogService>();
            services.AddHttpClient<IRandomAnimalService, ShibeOnlineService>();
            services.AddHttpClient<ICdnShibeOnlineService, CdnShibeOnlineService>();
            #endregion
        }
    }
}
