using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PVK.Application.Services.Account;
using PVK.Application.Services.Brand;
using PVK.Application.Services.SMSTemplate;
using PVK.Application.Services.SmsUrl;
using PVK.EFCore.Data.BrandScope;
using PVK.EFCore.Data.SMSTemplate;
using PVK.EFCore.Data.SmsUrlScope;
using PVK.Interfaces.Services.Account;
using PVK.Interfaces.Services.Brand;
using PVK.Interfaces.Services.SMSTemplate;
using PVK.Interfaces.Services.SmsUrl;

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
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountProcessor, AccountProcessor>();
            services.AddTransient<IBrandServices,BrandServices>();
            services.AddTransient<IBrandProcessor, BrandProcessor>();
            services.AddTransient<ISmsurlServices, SmsurlServices>();
            services.AddTransient<ISmsurlProcessor, SmsurlProcessor>();
            services.AddTransient<ISmsTemplateServices, SmsTemplateServices>();
            services.AddTransient<ISmsTemplateProcessor, SmsTemplateProcessor>();
        }

        public static IServiceCollection AddSqlDataBaseConnector(this IServiceCollection services,string connection)
        {
            services.AddDbContext<BrandContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<SmsurlContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<SmsTemplateContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));


            return services;
        }
    }
}
