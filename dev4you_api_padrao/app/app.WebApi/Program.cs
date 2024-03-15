using app.ExcelAdapter;
using app.ExcelAdapter.Microsoft.Extensions.DependencyInjection;
using app.RepositoryAdapter;
using app.WebApi.Configuration;
using app.WebApi.Extension;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;

namespace app.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                });

            // Configure Localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.TryAddSingleton(typeof(IStringLocalizerFactory), typeof(ResourceManagerStringLocalizerFactory));
            builder.Services.TryAddSingleton(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));

            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();

            // Add Jwt Token Authorization Handler
            builder.Services.AddJwt();
            builder.Services
                .AddApplication()
                .AddExcelAdapter()
                .AddRepositoryAdapter(builder.Configuration.SafeGet<RepositoryAdapterConfiguration>());

            builder.Services.AddAutoMapper(typeof(WebApiMapperProfile), typeof(ExcelMapperProfile));

            builder.Services.AddControllers()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>())
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });

            builder.Services.Configure<KestrelServerOptions>(builder.Configuration.GetSection("Kestrel"));

            // Add API versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}