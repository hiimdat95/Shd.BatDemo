using Dapper;
using Dapper.Oracle;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BatDemo.Repositories
{
    public interface ICustomDapperForOracleRepository
    {
        T Get<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null);
        Task<T> GetAsync<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null);
        List<T> GetAll<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null);
        Task<List<T>> GetAllAsync<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null);
        IEnumerable<T> GetAlls<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null);
        Task<IEnumerable<T>> GetAllsAsync<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null);
        Task<SqlMapper.GridReader> MultiQueryAsync(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null);
        void Execute(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null);
        Task ExecuteAsync(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null);
    }
}






