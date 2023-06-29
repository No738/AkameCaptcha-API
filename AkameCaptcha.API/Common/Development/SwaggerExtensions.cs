using Swashbuckle.AspNetCore.SwaggerGen;

namespace AkameCaptcha.API.Common.Development
{
    /// <summary>
    /// Extension methods for Swagger
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Configures swagger gen
        /// </summary>
        /// <param name="options">Swagger gen options</param>
        public static void ConfigureSwaggerGen(this SwaggerGenOptions options)
        {
            var xmlFilesPaths = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
            foreach (var xmlFilePath in xmlFilesPaths)
            {
                options.IncludeXmlComments(xmlFilePath);
            }
            
            options.OperationFilter<DefaultStatusCodesOperationFilter>();
        }
        
        /// <summary>
        /// Registers swagger and swagger UI middlewares
        /// </summary>
        /// <param name="app">Application builder</param>
        public static void UseSwaggerMiddlewares(this IApplicationBuilder app)
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