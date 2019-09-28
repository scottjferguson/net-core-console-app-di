using BatchProcessor.Common.Application;
using BatchProcessor.Common.Extensions;

namespace BatchProcessor.Fulfillment
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreateApplicationHostBuilder(args).Build().Run();
        }

        public static IApplicationHostBuilder CreateApplicationHostBuilder(string[] args) =>
            ApplicationHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
