﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
using PVK.EFCore.Data.SmsUrlScope;
using PVK.Interfaces.Services.Account;
using PVK.Interfaces.Services.Brand;
using PVK.Interfaces.Services.Token;
using TokenContext = PVK.EFCore.Data.TokenScope.TokenContext;
using System.Configuration;
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
using PVK.Interfaces.Services.Address;
using PVK.Application.Services.Address;
using PVK.EFCore.Data.AddressScope;
using PVK.Interfaces.Services.ContactUs;
using PVK.Application.Services.ContactUs;
using PVK.EFCore.Data.ContactUsScope;
using PVK.Interfaces.Services.BannerImage;
using PVK.Application.Services.BannerImage;
using PVK.EFCore.Data.BannerImagescope;
using PVK.EFCore.Data.BannerScope;
using PVK.Interfaces.Services.Newslatter;
using PVK.Application.Services.NewsLatter;
using PVK.EFCore.Data.NewsLetterSetupScope;
using PVK.Interfaces.Services.PickupLocation;
using PVK.Application.Services.PickupLocation;
using PVK.EFCore.Data.PickupLocationScope;
using PVK.Interfaces.Services.GallaryImage;
using PVK.Application.Services.GallaryImage;
using PVK.Interfaces.Services.Gallary;
using PVK.Application.Services.Gallary;
using PVK.Interfaces.Services.GallaryVideo;
using PVK.Application.Services.GallaryVideo;
using PVK.EFCore.Data.GallaryImageScope;
using PVK.EFCore.Data.GallaryVideoScope;
using PVK.EFCore.Data.GallaryScope;
using PVK.Interfaces.Services.Address;
using PVK.Application.Services.Address;
using PVK.EFCore.Data.AddressScope;
using PVK.Interfaces.Services.ContactUs;
using PVK.Application.Services.ContactUs;
using PVK.EFCore.Data.ContactUsScope;
using PVK.Interfaces.Services.Unit;
using PVK.Application.Services.Unit;
using PVK.EFCore.Data.UnitScope;

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

            services.AddScoped<IAddressProcessor, AddressProcessor>();
            services.AddScoped<IAddressServices, AddressServices>();

            services.AddScoped<IContactUsProcessor, ContactUsProcessor>();
            services.AddScoped<IContactUsServices, ContactUsServices>();

            services.AddScoped<IBannerImageProcessor, BannerImageProcessor>();
            services.AddScoped<IBannerImageService, BannerImageservice>();

            services.AddScoped<INewslatterProcessor, NewslatterProcessor>();
            services.AddScoped<INewslatterService, NewslatterService>();

            services.AddScoped<IPickuplocationProcessor, PickuplocationProcessor>();
            services.AddScoped<IPickuplocationService, PickuplocationService>();

            services.AddScoped<IGallaryImageProcessor, GallaryImageProcessor>();
            services.AddScoped<IGallaryImageServices, GallaryImageServices>();

            services.AddScoped<IGallaryProcessor, GallaryProcessor>();
            services.AddScoped<IGallaryServices, GallaryServices>();

            services.AddScoped<IGallaryVideoProcessor, GallaryVideoProcessor>();
            services.AddScoped<IGallaryVideoServices, GallaryVideoServices>();

            services.AddScoped<IAddressProcessor, AddressProcessor>();
            services.AddScoped<IAddressServices, AddressServices>();

            services.AddScoped<IContactUsProcessor, ContactUsProcessor>();
            services.AddScoped<IContactUsServices, ContactUsServices>();

            services.AddScoped<IUnitProcessor, UnitProcessor>();
            services.AddScoped<IUnitService, UnitService>();

        }

        public static IServiceCollection AddSqlDataBaseConnector(this IServiceCollection services,string connection)
        {
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors), ServiceLifetime.Scoped);

            services.AddDbContext<BrandContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));

            services.AddDbContext<TokenContext>(option => option.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));          
            services.AddDbContext<BannerContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
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
            services.AddDbContext<AddressContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<ContactUsContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<BannerImageContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<NewslettersetupContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<PickupLocationContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<GallaryImageContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<GallaryVideoContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<GallaryContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<AddressContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));
            services.AddDbContext<ContactUsContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));

            services.AddDbContext<UnitContext>(options => options.UseSqlServer(connection).EnableDetailedErrors(EnableDetailedErrors));



            return services;
        }
    }
}
