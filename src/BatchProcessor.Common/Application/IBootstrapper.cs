using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BatchProcessor.Common.Application
{
    public interface IBootstrapper
    {
        void ConfigureServices(IServiceCollection services);
        void Configure(IApplicationHostBuilder hostBuilder, ILoggingBuilder loggingBuilder);
    }
}
