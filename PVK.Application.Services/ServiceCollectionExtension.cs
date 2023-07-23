using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PVK.Application.Services.Brand;
using PVK.EFCore.Data.BrandScope;
using PVK.Interfaces.Services.Brand;

namespace PVK.Application.Services
{
    public static class ServiceCollectionExtension
    {
#if DEBUG
        private static readonly bool EnableDetailedErrors = true;
#else
        private static readonly bool EnableDetailedErrors = false;
#endif
        public static void AddInternalServices(this IServiceCollection services)
        {
            services.AddTransient<IBrandServices,BrandServices>();
            services.AddTransient<IBrandProcessor, BrandProcessor>();
        }

        public static IServiceCollection AddSqlDataBaseConnector(this IServiceCollection services,string connection)
        {
            services.AddDbContext<BrandContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            return services;
        }
    }
}
