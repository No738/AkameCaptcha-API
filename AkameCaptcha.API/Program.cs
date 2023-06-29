using System.Reflection;
using AkameCaptcha.Application.Common;
using FluentResults.Extensions.AspNetCore;

namespace AkameCaptcha.API
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AspNetCoreResult.Setup(x =>
            {
                x.DefaultProfile = new FluentResultsProfile();
            });
            
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var assemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;

            return Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder =>
                       {
                           webBuilder.UseStartup(assemblyName);
                       });
        }
    }
}