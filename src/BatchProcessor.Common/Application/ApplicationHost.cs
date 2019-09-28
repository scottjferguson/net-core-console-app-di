using BatchProcessor.Common.Application.Impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BatchProcessor.Common.Application
{
    public static class ApplicationHost
    {
        /// <summary>
        /// AspNetCore implementation here: https://github.com/aspnet/AspNetCore/blob/master/src/DefaultBuilder/src/WebHost.cs
        /// </summary>
        public static IApplicationHostBuilder CreateDefaultBuilder(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddLogging();

            var applicationFramework = new ApplicationFramework(services, args);

            return new DefaultApplicationHostBuilder(applicationFramework);
        }
    }
}
