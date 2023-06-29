using AkameCaptcha.API.Common;
using AkameCaptcha.API.Common.Development;
using AkameCaptcha.API.Middleware;
using AkameCaptcha.Application;
using Microsoft.AspNetCore.Mvc;

namespace AkameCaptcha.API
{
    /// <summary>
    /// Application configuration class 
    /// </summary>
    public sealed class Startup
    {
        /// <summary>
        /// Adding development services
        /// </summary>
        /// <param name="services">Services collection</param>
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            ConfigureServices(services);
            
            services.AddSwaggerGen(options => options.ConfigureSwaggerGen());
        }
        
        /// <summary>
        /// Adding services to a container
        /// </summary>
        /// <param name="services">Services collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMediatR(services.RegisterApplicationDependencies)
                .Configure<MvcOptions>(options =>
                {
                    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
                })
                .Configure<ApiBehaviorOptions>(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                })
                .AddControllers(options =>
                {
                    options.Filters.Add<ValidationActionFilter>();
                });
        }

        /// <summary>
        /// Configure development environment of application
        /// </summary>
        /// <param name="app">Application builder</param>
        public void ConfigureDevelopment(IApplicationBuilder app)
        {
            Configure(app);

            app.UseSwaggerMiddlewares();
        }
        
        /// <summary>
        /// Configure application
        /// </summary>
        /// <param name="app">Application builder</param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}