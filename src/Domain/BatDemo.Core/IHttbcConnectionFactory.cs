using System.Data;

namespace BatDemo
{
    public interface IHttbcConnectionFactory
    {
        IDbConnection CreateConnection(string connectionName);
    }
}






