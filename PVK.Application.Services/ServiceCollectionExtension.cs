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
using PVK.Interfaces.Services.Role;
using PVK.Application.Services.Role;
using PVK.EFCore.Data.RoleScope;
using PVK.Interfaces.Services.UserRole;
using PVK.Application.Services.UserRole;
using PVK.EFCore.Data.UserRoleScope;
using PVK.Interfaces.Services.Category;
using PVK.Application.Services.Category;
using PVK.EFCore.Data.CategoryScope;

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
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IRoleProcessor, RoleProcessor>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserRoleProcessor, UserRoleProcessor>();
            services.AddScoped<ICategoryProcessor, CategoryProcessor>();
            services.AddScoped<ICategoryService, CategoryService>();
        }

        public static IServiceCollection AddSqlDataBaseConnector(this IServiceCollection services,string connection)
        {
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors), ServiceLifetime.Scoped);

            services.AddDbContext<BrandContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));

            services.AddDbContext<TokenContext>(option => option.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));          
            services.AddDbContext<BrandContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<SmsurlContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<SmsTemplateContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<RoleContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<UserRoleContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));

            services.AddDbContext<CategoryContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));

            return services;
        }
    }
}
