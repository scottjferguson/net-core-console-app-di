using BatchProcessor.Common.Application;
using BatchProcessor.Common.Data;
using BatchProcessor.Common.Extensions;
using BatchProcessor.Fulfillment.Controllers;
using Core.Data;
using Core.Plugins.SQLServer.Wrappers;
using Core.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetCore.AutoRegisterDi;

namespace BatchProcessor.Fulfillment
{
    public class Startup : IBootstrapper
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .RegisterAssemblyPublicNonGenericClasses(typeof(Program).Assembly)
                .Where(type => type.UnlessAutoWiringOptOut())
                .AsPublicImplementedInterfaces();

            services.AddTransient<IDatabase, SQLServerDatabase>();
            services.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();
            services.AddTransient<IBatchProcessController, WelcomeLetterController>();
        }

        // This method gets called by the runtime. Use this method to configure the request pipeline.
        public void Configure(IApplicationHostBuilder hostBuilder, ILoggingBuilder loggingBuilder)
        {
            hostBuilder.ApplicationFramework.SetEntryPointType<WelcomeLetterController>();

            loggingBuilder?.AddConsole();
        }
    }
}
