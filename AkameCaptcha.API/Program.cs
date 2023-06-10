using AkameCaptcha.API.Middleware;
using AkameCaptcha.Application.Common;
using AkameCaptcha.Application;
using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AkameCaptcha.API
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<MvcOptions>(options =>
            {
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            });
            
            ConfigureAndRegisterServices(builder.Services);
            
            if (builder.Environment.IsDevelopment())
                builder.Services.AddSwaggerGen(SetupSwaggerGen);

            AspNetCoreResult.Setup(x =>
            {
                x.DefaultProfile = new FluentResultsProfile();
            });

            var app = builder.Build();
            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
                UseSwaggerMiddlewares(app);

            app.MapControllers();
            app.Run();
        }

        private static void ConfigureAndRegisterServices(IServiceCollection services)
        {
            services.AddMediatR(services.RegisterApplicationDependencies)
                    .AddControllers();
        }
        
        private static void SetupSwaggerGen(SwaggerGenOptions options)
        {
            const string XmlFilename = $"AkameCaptcha.API.xml";

            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, XmlFilename));
        }

        private static void UseSwaggerMiddlewares(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}