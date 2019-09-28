using Core.Exceptions;
using Core.Providers;
using Microsoft.Extensions.Configuration;

namespace BatchProcessor.Common.Data
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Get(string connectionName)
        {
            string connectionString = _configuration.GetConnectionString(connectionName);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new CoreException("Connection String cannot be null or empty");
            }

            return connectionString;
        }

        public string Get()
        {
            return Get("DefaultConnection");
        }
    }
}
