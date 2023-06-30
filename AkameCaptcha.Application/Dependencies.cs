using AkameCaptcha.Application.Common.Behaviours;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AkameCaptcha.Application
{
    /// <summary>
    /// Application layer dependencies
    /// </summary>
    public static class Dependencies
    {
        /// <summary>
        /// Register layer dependencies
        /// </summary>
        /// <param name="serviceCollection">Services collection</param>
        /// <param name="mediatrConfiguration">MediatR configuration</param>
        public static void RegisterApplicationDependencies(this IServiceCollection serviceCollection, MediatRServiceConfiguration mediatrConfiguration)
        {
            var currentAssembly = typeof(Dependencies).Assembly;
            serviceCollection.AddValidatorsFromAssembly(currentAssembly, ServiceLifetime.Transient);

            mediatrConfiguration.RegisterServicesFromAssembly(currentAssembly);
            mediatrConfiguration.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        }
    }
}