using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WeatherApp.BusinessLayer.Aggregators;
using WeatherApp.BusinessLayer.Factories;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;
using WeatherApp.BusinessLayer.Interfaces.PresentationLayer;
using WeatherApp.BusinessLayer.Interfaces.ServiceLayer;
using WeatherApp.BusinessLayer.Managers;
using WeatherApp.BusinessLayer.Options;
using WeatherApp.ServiceLayer;
using WeatherApp.ServiceLayer.Factories;
using WeatherApp.WebApi.Models.Factories;
using WeatherApp.WebApi.Shared;

namespace WeatherApp.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(
                        "http://localhost:8080",
                        "https://localhost:8080");
                });
            });

            services.AddControllers();
            services.AddHttpClient();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    // TODO ALBA: think about that
                    // ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    // TODO ALBA: think about that
                    // ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                });

            // Web
            services.AddTransient<IForecastDataModelFactory, ForecastDataModelFactory>();
            services.AddTransient<IJwtTokenFactory, JwtTokenFactory>();

            // BL
            services.AddTransient<IAppSettingsManager, AppSettingsManager>();
            services.AddTransient<IForecastDataManager, ForecastDataManager>();
            services.AddTransient<ILoginManager, LoginManager>();
            services.AddTransient<IForecastDataAverageByDayAggregator, ForecastDataAverageByDayAggregator>();

            services.Configure<JwtOptions>(_configuration.GetSection("Jwt"));

            // SL
            services.AddTransient<IForecastDataFetcher, OpenWeatherForecastDataFetcher>();
            services.AddTransient<IForecastDataFactory, ForecastDataFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
