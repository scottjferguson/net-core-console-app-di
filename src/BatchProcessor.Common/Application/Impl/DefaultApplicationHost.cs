namespace BatchProcessor.Common.Application.Impl
{
    public class DefaultApplicationHost : IApplicationHost
    {
        public ApplicationFramework ApplicationFramework { get; }

        public DefaultApplicationHost(ApplicationFramework applicationFramework)
        {
            ApplicationFramework = applicationFramework;
        }
    }
}
