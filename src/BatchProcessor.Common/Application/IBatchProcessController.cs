using System;

namespace BatchProcessor.Common.Application
{
    public interface IBatchProcessController : IDisposable
    {
        void Process();
    }
}
