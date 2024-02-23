using System.Text.Json.Serialization;
using RinhaBackend2024Q1.Exceptions;

namespace RinhaBackend2024Q1.Entities;

public class Client
{
    [JsonIgnore]
    public int Id { get; init; }

    [JsonPropertyName("saldo")] public int Balance { get; private set; }

    [JsonPropertyName("limite")] public uint Limit { get; init; }

    public void Credit(uint amount)
    {
        Balance += (int)amount;
    }

    public void Debit(uint amount)
    {
        if (Balance - amount < Limit * -1)
        {
            DomainException.ThrowInsufficientLimit();
        }

        Balance -= (int)amount;
    }
}