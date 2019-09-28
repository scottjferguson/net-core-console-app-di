using BatchProcessor.Common.Application;
using BatchProcessor.Common.Application.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace BatchProcessor.Common.Extensions
{
    public static class ApplicationHostBuilderExtensions
    {
        public static IApplicationHostBuilder UseStartup<TStartup>(this IApplicationHostBuilder hostBuilder) where TStartup : IBootstrapper
        {
            hostBuilder.ApplicationFramework.SetBootstrapperType<TStartup>();

            return hostBuilder;
        }

        public static IApplicationHost Build(this IApplicationHostBuilder hostBuilder)
        {
            //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //if (String.IsNullOrWhiteSpace(environment))
            //    throw new ArgumentNullException("Environment not found in ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
                ;

            IConfiguration configuration = builder.Build();

            hostBuilder.ApplicationFramework.Services.AddTransient((sp) => configuration);

            IBootstrapper bootstrapper = (IBootstrapper)Activator.CreateInstance(hostBuilder.ApplicationFramework.BootstrapperType, new[] { configuration });
            
            bootstrapper.ConfigureServices(hostBuilder.ApplicationFramework.Services);

            hostBuilder.ApplicationFramework.BuildServiceProvider();

            ILoggingBuilder loggingBuilder = hostBuilder.ApplicationFramework.ServiceProvider.GetService<ILoggingBuilder>();

            bootstrapper.Configure(hostBuilder, loggingBuilder);

            return new DefaultApplicationHost(hostBuilder.ApplicationFramework);
        }
    }
}
