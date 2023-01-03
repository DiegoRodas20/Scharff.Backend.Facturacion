using Dapper;
using JKM.UTILITY.Utils;
using Npgsql;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Direction.RegisterDirection
{
    public   class RegisterAddressRepository : IRegisterAddressRepository
    {
        private readonly IDbConnection _connection;

        public RegisterAddressRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> RegisterAddress(AddressModel address)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

                    string insert = @"  INSERT INTO nsf.address 
                                            (type_param,
                                            client_id,
                                            unit_id,
                                            address,
                                            creation_date,
                                            creation_author
                                            )
                                        VALUES 
                                            (@type_param, 
                                            @client_id,
                                            @unit_id,
                                            @address
                                            @creation_date,
                                            @creation_author
                                            ) RETURNING id;";

                    int idInsert = await connection.ExecuteScalarAsync<int>(insert, address);
                    trans.Complete();
                    return idInsert;
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }

        }
    }
}
