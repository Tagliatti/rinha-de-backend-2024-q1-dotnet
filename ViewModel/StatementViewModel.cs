using System.Text.Json.Serialization;
using RinhaBackend2024Q1.Entities;

namespace RinhaBackend2024Q1.ViewModel;

public record BalanceViewModel
{
    [JsonPropertyName("total")] public int Balance { get; init; }
    [JsonPropertyName("data_extrato")] public DateTime Date { get; } = DateTime.UtcNow;
    [JsonPropertyName("limite")] public uint Limit { get; init; }
}

public record StatementViewModel
{
    [JsonPropertyName("saldo")] public BalanceViewModel Balance { get; init; }

    [JsonPropertyName("ultimas_transacoes")]
    public IEnumerable<Transaction> Transactions { get; init; }

    public StatementViewModel(Client client, IEnumerable<Transaction> transactions)
    {
        Balance = new BalanceViewModel
        {
            Balance = client.Balance,
            Limit = client.Limit
        };
        Transactions = transactions;
    }
}