using Dapper;
using Dapper.Oracle;
using BatDemo.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BatDemo.EntityFrameworkCore.Repositories
{
    public class CustomDapperForOracleRepository : ICustomDapperForOracleRepository
    {
        private readonly IHttbcConnectionFactory _httbcConnectionFactory;
        private readonly string _connectionName;

        public CustomDapperForOracleRepository(IHttbcConnectionFactory httbcConnectionFactory)
        {
            _httbcConnectionFactory = httbcConnectionFactory;
            _connectionName = BatDemoConsts.ConnectionStringName;
        }

        public T Get<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null)
        {
            using IDbConnection db = _httbcConnectionFactory.CreateConnection(connectionName ?? _connectionName);
            return db.QueryFirst<T>(sp, parms, commandType: commandType);
        }
        public async Task<T> GetAsync<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null)
        {
            using IDbConnection db = _httbcConnectionFactory.CreateConnection(connectionName ?? _connectionName);
            return await db.QueryFirstOrDefaultAsync<T>(sp, parms, commandType: commandType);
        }

        public List<T> GetAll<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null)
        {
            using IDbConnection db = _httbcConnectionFactory.CreateConnection(connectionName ?? _connectionName);
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }
        public async Task<List<T>> GetAllAsync<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null)
        {
            using IDbConnection db = _httbcConnectionFactory.CreateConnection(connectionName ?? _connectionName);
            return (await db.QueryAsync<T>(sp, parms, commandType: commandType)).ToList();
        }

        public IEnumerable<T> GetAlls<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null)
        {
            using IDbConnection db = _httbcConnectionFactory.CreateConnection(connectionName ?? _connectionName);
            var item = db.Query<T>(sp, parms, commandType: commandType);
            return item;
        }

        public async Task<IEnumerable<T>> GetAllsAsync<T>(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null)
        {
            using IDbConnection db = _httbcConnectionFactory.CreateConnection(connectionName ?? _connectionName);
            return await db.QueryAsync<T>(sp, parms, commandType: commandType);
        }
        public async Task<SqlMapper.GridReader> MultiQueryAsync(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null)
        {
            using IDbConnection db = _httbcConnectionFactory.CreateConnection(connectionName ?? _connectionName);
            return await db.QueryMultipleAsync(sp, parms, commandType: commandType);
        }

        public void Execute(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null)
        {
            using IDbConnection db = _httbcConnectionFactory.CreateConnection(connectionName ?? _connectionName);
            db.Execute(sp, parms, commandType: commandType);
        }
        public async Task ExecuteAsync(string sp, OracleDynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, string connectionName = null)
        {
            using IDbConnection db = _httbcConnectionFactory.CreateConnection(connectionName ?? _connectionName);
            await db.ExecuteAsync(sp, parms, commandType: commandType);
        }

    }
}






