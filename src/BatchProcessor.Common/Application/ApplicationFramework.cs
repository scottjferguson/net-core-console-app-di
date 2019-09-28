using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace BatchProcessor.Common.Application
{
    public class ApplicationFramework
    {
        public IServiceCollection Services { get; }

        private IServiceProvider _serviceProvider;
        public IServiceProvider ServiceProvider
        {
            get
            {
                return _serviceProvider;
            }
        }

        private Type _bootstrapperType;
        public Type BootstrapperType
        {
            get
            {
                return _bootstrapperType;
            }
        }

        private Type _entryPointType;
        public Type EntryPointType
        {
            get
            {
                return _entryPointType;
            }
        }

        public string[] Args { get; }
        private Stopwatch _stopwatch;

        public ApplicationFramework(IServiceCollection services, string[] args)
        {
            Services = services;
            Args = args;
            _stopwatch = Stopwatch.StartNew();
        }

        public void SetBootstrapperType<TBootstrapper>() where TBootstrapper : IBootstrapper
        {
            _bootstrapperType = typeof(TBootstrapper);
        }

        public void SetEntryPointType<TBatchProcessController>() where TBatchProcessController : IBatchProcessController
        {
            _entryPointType = typeof(TBatchProcessController);
        }

        public void BuildServiceProvider()
        {
            _serviceProvider = Services.BuildServiceProvider();
        }

        public string GetElaspedSeconds()
        {
            _stopwatch.Stop();

            return _stopwatch.Elapsed.Seconds.ToString();
        }
    }
}
