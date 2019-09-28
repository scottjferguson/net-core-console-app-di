using Microsoft.AspNetCore.Hosting;

namespace BatchProcessor.Common.Application.Impl
{
    public class DefaultApplicationHostBuilder : WebHostBuilder, IApplicationHostBuilder
    {
        public ApplicationFramework ApplicationFramework { get; }

        public DefaultApplicationHostBuilder(ApplicationFramework applicationFramework)
        {
            ApplicationFramework = applicationFramework;
        }
    }
}
