using Dapper;
using JKM.UTILITY.Utils;
using Npgsql;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Direction.DeleteDirection
{
    public class DeleteAddressRepository : IDeleteAddressRepository
    {
        private readonly IDbConnection _connection;

        public DeleteAddressRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> DeleteAddress(int Id)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

                    string delete = @"  DELETE  
                                        FROM nsf.address
                                        WHERE 
                                        ""id""= @Id ;";
                    var queryArgs = new { Id };
                    int hasDelete = await connection.ExecuteAsync(delete, queryArgs);
                    trans.Complete();

                    return hasDelete;
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
