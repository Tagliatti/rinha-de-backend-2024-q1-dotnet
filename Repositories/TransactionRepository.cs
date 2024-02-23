using System.Data;
using Dapper;
using RinhaBackend2024Q1.Entities;

namespace RinhaBackend2024Q1.Repositories;

public class TransactionRepository(IDbConnection dbConnection)
{
    public async Task<bool> CreateAsync(Transaction transaction)
    {
        var sql = """
                  INSERT INTO transactions (client_id, amount, type, description, created_at)
                  VALUES (@ClientId, @Amount, @Type, @Description, @CreatedAt)
                  """;
        var affectedRows = await dbConnection.ExecuteAsync(sql,
            new
            {
                transaction.ClientId,
                Amount = (int)transaction.Amount,
                transaction.Type,
                transaction.Description,
                transaction.CreatedAt
            });
        return affectedRows > 0;
    }

    public async Task<IEnumerable<Transaction>> ListLatestAsync(int clientId)
    {
        return await dbConnection
            .QueryAsync<Transaction>(
                "SELECT id, client_id, amount, type, description, created_at FROM transactions WHERE client_id = @ClientId ORDER BY created_at DESC LIMIT 10",
                new { clientId });
    }
}