using BatchProcessor.Common.Application;
using Core.Data;
using System;

namespace BatchProcessor.Fulfillment.Controllers
{
    public class WelcomeLetterController : IBatchProcessController
    {
        private readonly IDatabase _database;

        public WelcomeLetterController(IDatabase database)
        {
            _database = database;
        }

        public void Process()
        {
            string serverName = _database.GetServerName();

            Console.WriteLine(serverName);
        }
        
        public void Dispose()
        {
            
        }
    }
}
