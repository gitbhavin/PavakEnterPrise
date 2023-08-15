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
using PVK.Interfaces.Services.Product;
using PVK.Application.Services.Product;
using PVK.EFCore.Data.ProductScope;
using PVK.Interfaces.Services.Review;
using PVK.Application.Services.Review;
using PVK.Interfaces.Services.Wholeseller;
using PVK.Application.Services.Wholeseller;
using PVK.EFCore.Data.ReviewScope;
using PVK.EFCore.Data.WholesellerScope;
using PVK.Interfaces.Services.Email;
using PVK.Application.Services.Email;
using PVK.Interfaces.Services.EmailTemplate;
using PVK.Application.Services.EmailTemplate;
using PVK.Interfaces.Services.Order;
using PVK.Application.Services.Order;
using PVK.EFCore.Data.OrderScope;
using PVK.EFCore.Data.OrderDetailscope;
using PVK.EFCore.Data.EmailScope;
using PVK.EFCore.Data.EmailTemplateScope;
using PVK.Interfaces.Services.OrderStatus;
using PVK.Application.Services.OrderStatus;
using PVK.EFCore.Data.OrderStatusScope;
using PVK.Interfaces.Services.Payment;
using PVK.Application.Services.Payment;
using PVK.EFCore.Data.PaymentScope;
using PVK.Interfaces.Services.ProductImage;
using PVK.Application.Services.ProductImage;
using PVK.EFCore.Data.ProductImageScope;

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
            services.AddScoped<IProductProcessor, ProductProcessor>();
            services.AddScoped<IProductService, ProductService >();
            services.AddScoped<IReviewProcessor, ReviewProcessor>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IWholesellerProcessor, WholesellerProcessor>();
            services.AddScoped<IWholesellerService, WholesellerService>();
            services.AddScoped<IEmailProcessor, EmailProcessor>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IEmailtemplateProcessor, EmailTemplateProcessor>();
            services.AddScoped<IEmailtemplateService, EmailTemplateService>();

            services.AddScoped<IOrderProcessor, OrderProcessor>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IOrderStatusProcessor, OrderstatusProcessor>();
            services.AddScoped<IOrderStatusService, OrderstatusService>();

            services.AddScoped<IPaymentProcessor, PaymentProcessor>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IProductimageProcessor, ProductimageProcessor>();
            services.AddScoped<IProductimageService, ProductimageService>();
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
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<ReviewContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<WholesellerContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<OrderContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<OrderDetailContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<EmailContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<EmailTemplateContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<OrderStatusContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<PaymentContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<ProductImageContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));

            return services;
        }
    }
}
