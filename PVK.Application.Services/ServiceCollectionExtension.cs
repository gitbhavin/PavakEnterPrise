using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PVK.Application.Services.Account;
using PVK.Application.Services.Brand;
using PVK.Application.Services.SMSTemplate;
using PVK.Application.Services.SmsUrl;
using PVK.Application.Services.Token;
using PVK.EFCore.Data.BrandScope;
using PVK.EFCore.Data.SmsUrlScope;
using PVK.EFCore.Data.UserScope;
using PVK.Interfaces.Services.Account;
using PVK.EFCore.Data.TokenScope;
using PVK.EFCore.Data.SMSTemplate;
using PVK.Interfaces.Services.Brand;
using PVK.Interfaces.Services.Token;
using TokenContext = PVK.EFCore.Data.TokenScope.TokenContext;
using Microsoft.Extensions.Configuration;
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
        public static void AddInternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountProcessor, AccountProcessor>();
            services.AddTransient<IBrandServices,BrandServices>();
            services.AddTransient<IBrandProcessor, BrandProcessor>();
           services.AddScoped<ISecurityService, SecurityService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ITokenProcessor, TokenProcessor>();
            var bearerToken = new BearerTokensOptions();
            configuration.Bind("BearerTokens", bearerToken);
            services.AddSingleton(bearerToken);
            services.AddTransient<ISmsurlServices, SmsurlServices>();
            services.AddTransient<ISmsurlProcessor, SmsurlProcessor>();
            services.AddTransient<ISmsTemplateServices, SmsTemplateServices>();
            services.AddTransient<ISmsTemplateProcessor, SmsTemplateProcessor>();
        }

        public static IServiceCollection AddSqlDataBaseConnector(this IServiceCollection services,string connection)
        {
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors), ServiceLifetime.Transient);

            services.AddDbContext<BrandContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors), ServiceLifetime.Transient);

            services.AddDbContext<TokenContext>(option => option.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));          
            services.AddDbContext<BrandContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<SmsurlContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<SmsTemplateContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));


            return services;
        }
    }
}
