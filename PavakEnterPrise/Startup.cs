using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using PVK.Application.Services;
using PVK.QueryHandlers.Helper;

namespace PavakEnterPrise
{
    public class Startup
    {
        private AppOptions appOptions;
        private readonly string myAllowSpecificOrigins = "*";

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.Configuration = configuration;
            this.Environment = environment;
        }

        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationSection optionSection = Configuration.GetSection(nameof(AppOptions));
            services.Configure<AppOptions>(optionSection);
            appOptions = optionSection.Get<AppOptions>();

            //will generate Partial class Statup.cs  and will addbelow static method
            //Task.Run(RegisterAutoMapperConfig);

            this.RegisterServices(services);

            services.Configure<StripeSettings>(Configuration.GetSection("StripeSettings"));

            services.AddResponseCaching();
            services.AddMemoryCache();

            // services.AddSession();
            services.Configure<FormOptions>(
                x =>
                {
                    x.ValueLengthLimit = int.MaxValue;
                    x.MultipartBodyLengthLimit = int.MaxValue;
                });

            services.AddMvc();
            // services.AddMvcCore();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 });


            PVK.Application.Services.ServiceCollectionExtension.AddInternalServices(services, Configuration);
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "PVK API",
                        Version = "v1",
                        Description = "Description for the API goes here.",
                        Contact = new OpenApiContact
                        {
                            Name = "Bhavin Patel",
                            Email = string.Empty,
                            // Url = new Uri("https://coderjony.com/"),
                        },
                    });
                });
            var secret = Configuration.GetSection("BearerTokens:Key").Value;
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    
                };
            });
            services.AddScoped(_ =>
            {
                return new BlobServiceClient(Configuration.GetConnectionString("AzureBlobStorage"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy(myAllowSpecificOrigins,
                    builder => builder.AllowAnyOrigin()
                                       .AllowAnyMethod()
                                       .AllowAnyHeader()
                    );
            });
            services.Configure<ImageSettings>(Configuration.GetSection("ImageSettings"));
            // services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IHostApplicationLifetime lifetime)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PVK.API");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(myAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddSqlDataBaseConnector(this.Configuration.GetConnectionString("MyConnectionString"));
            services.AddInternalServices(this.Configuration);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IConfiguration>(Configuration);


        }
    }
}
