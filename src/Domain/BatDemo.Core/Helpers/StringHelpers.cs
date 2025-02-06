using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatDemo.Helpers
{
    public static class StringHelpers
    {
        public static string BuildOracleConnectionString(string host, string port, string sid, string user, string password)
        {
            return $"Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = {host})(PORT = {port})))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = {sid}))); User Id = {user}; Password = {password};";
        }
    }
}






