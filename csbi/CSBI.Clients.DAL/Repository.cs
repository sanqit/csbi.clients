namespace CSBI.Clients.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Contracts;
    using Dapper;
    using Dapper.FastCrud;
    using Entities;

    public class Repository : IRepository
    {
        private const string SpSearchClients = "spSearchClients";

        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
            OrmConfiguration.DefaultDialect = SqlDialect.MsSql;

            SqlMapper.SetTypeMap(
                typeof(ClientEntity),
                new CustomPropertyTypeMap(
                    typeof(ClientEntity),
                    (type, columnName) =>
                        type.GetProperties()
                            .FirstOrDefault(prop =>
                                prop.GetCustomAttributes(false)
                                    .OfType<ColumnAttribute>()
                                    .Any(attr => attr.Name == columnName))));
            SqlMapper.SetTypeMap(
                typeof(AddressEntity),
                new CustomPropertyTypeMap(
                    typeof(AddressEntity),
                    (type, columnName) =>
                        type.GetProperties()
                            .FirstOrDefault(prop =>
                                prop.GetCustomAttributes(false)
                                    .OfType<ColumnAttribute>()
                                    .Any(attr => attr.Name == columnName || (attr.Name == "id" && columnName == "address_id")))));
        }

        public async Task<IEnumerable<ClientEntity>> GetListAsync(Dictionary<string, object> filter, int? offset = null, int? limit = null)
        {
            using (var connection = CreateConnection())
            {
                var parameters = new DynamicParameters();
                foreach (var o in filter)
                {
                    parameters.Add($"@{o.Key}", o.Value);
                }

                if (offset.HasValue)
                {
                    parameters.Add("@offset", offset);
                }

                if (limit.HasValue)
                {
                    parameters.Add("@limit", limit);
                }

                try
                {
                    var lookup = new Dictionary<Guid, ClientEntity>();
                    await connection.QueryAsync<ClientEntity, AddressEntity, ClientEntity>(SpSearchClients,
                         (entity, s) =>
                         {
                             if (!lookup.ContainsKey(entity.Id))
                             {
                                 lookup.Add(entity.Id, entity);
                             }

                             if (lookup[entity.Id].Addresses == null)
                                 lookup[entity.Id].Addresses = new List<AddressEntity>();
                             lookup[entity.Id].Addresses.Add(s);
                             return lookup[entity.Id];
                         }, parameters,
                         splitOn: "address_id",
                         commandType: CommandType.StoredProcedure);

                    return lookup.Values;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task<int> GetCountAsync()
        {
            using (var connection = CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>($"SELECT COUNT(*) FROM {ClientsMetadata.TableName}");
            }
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
