using Microsoft.EntityFrameworkCore;
using Mr.ManoelStore.Repositories;

namespace Mr.ManoelStore.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddData(configuration)
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MrManoelStoreCs");
            services.AddDbContext<MrManoelStoreDbContext>(o => o.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPeditoRepository, PeditoRepository>();

            return services;
        }
    }
}
