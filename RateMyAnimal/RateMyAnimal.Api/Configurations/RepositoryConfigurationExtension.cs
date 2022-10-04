using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Infrastructure.Repository;

namespace RateMyAnimal.Api.Configurations
{
    public static class RepositoryConfigurationExtension
    {
        public static void AddRepositoryDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
