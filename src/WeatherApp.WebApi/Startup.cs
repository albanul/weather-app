using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherApp.BusinessLayer.Aggregators;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;
using WeatherApp.BusinessLayer.Interfaces.ServiceLayer;
using WeatherApp.BusinessLayer.Managers;
using WeatherApp.ServiceLayer;
using WeatherApp.ServiceLayer.Factories;
using WeatherApp.WebApi.Shared;

namespace WeatherApp.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();

            // BL
            services.AddTransient<IAppSettingsManager, AppSettingsManager>();
            services.AddTransient<IForecastDataManager, ForecastDataManager>();
            services.AddTransient<IForecastDataAverageByDayAggregator, ForecastDataAverageByDayAggregator>();

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
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
