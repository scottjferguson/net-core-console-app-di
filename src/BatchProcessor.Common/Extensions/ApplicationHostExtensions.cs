using BatchProcessor.Common.Application;
using Microsoft.Extensions.Logging;
using System;

namespace BatchProcessor.Common.Extensions
{
    public static class ApplicationHostExtensions
    {
        public static void Run(this IApplicationHost host)
        {
            LogStart(host.ApplicationFramework);

            Type entryPointType = host.ApplicationFramework.EntryPointType;

            using (IBatchProcessController batchProcessController = host.ApplicationFramework.ServiceProvider.GetService(typeof(IBatchProcessController)) as IBatchProcessController)
            {
                batchProcessController.Process();
            }

            LogEnd(host.ApplicationFramework);
        }

        private static void LogStart(ApplicationFramework applicationFramework)
        {
            //ILogger<ApplicationHostExtensions> logger = 
            //    applicationFramework.ServiceProvider
            //        .GetService<ILoggerFactory>()
            //        .CreateLogger<ApplicationHostExtensions>();

            //logger.LogInformation("");
        }

        private static void LogEnd(ApplicationFramework applicationFramework)
        {
            
        }
    }
}
