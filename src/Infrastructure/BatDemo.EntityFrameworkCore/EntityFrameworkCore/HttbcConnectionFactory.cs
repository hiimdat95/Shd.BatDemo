using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BatDemo.EntityFrameworkCore
{
    public class HttbcConnectionFactory : IHttbcConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public HttbcConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection(string connectionName)
        {
            var connectionString = _configuration.GetConnectionString(connectionName);
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException($"Connection string '{connectionName}' not found.");

            // Determine the database type based on connection name or another logic
            // Here, we'll use naming conventions for simplicity
            if (connectionName.StartsWith("SqlServer"))
            {
                return new SqlConnection(connectionString);
            }
            else
            {
                // Default use Sql
                return new SqlConnection(connectionString);
                /////throw new NotSupportedException($"Database type for connection '{connectionName}' is not supported.");
            }
        }
    }
}