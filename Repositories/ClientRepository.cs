using System.Data;
using Dapper;
using RinhaBackend2024Q1.Entities;

namespace RinhaBackend2024Q1.Repositories;

public class ClientRepository(IDbConnection dbConnection)
{
    public async Task<Client?> FindByIdAsync(int id)
    {
        return await dbConnection
            .QueryFirstOrDefaultAsync<Client>("SELECT id, balance, \"limit\" FROM clients WHERE id = @Id", new { id });
    }
    public async Task<Client?> FindByIdForUpdateAsync(int id)
    {
        return await dbConnection
            .QueryFirstOrDefaultAsync<Client>("SELECT id, balance, \"limit\" FROM clients WHERE id = @Id FOR UPDATE", new { id });
    }

    public async Task<bool> UpdateBalanceAsync(Client client)
    {
        var sql = "UPDATE clients SET balance = @Balance WHERE id = @Id";
        var affectedRows = await dbConnection.ExecuteAsync(sql, new { client.Id, client.Balance });

        return affectedRows > 0;
    }
}