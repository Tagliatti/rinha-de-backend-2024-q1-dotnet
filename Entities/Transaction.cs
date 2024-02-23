using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RinhaBackend2024Q1.Entities;

public class Transaction
{
    [JsonIgnore]
    public long Id { get; init; }

    [JsonIgnore]
    public int ClientId { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    [JsonPropertyName("valor")]
    public uint Amount { get; init; }

    [Required]
    [RegularExpression("^[c|d]$")]
    [JsonPropertyName("tipo")]
    public char Type { get; init; }

    [Required]
    [MinLength(1)]
    [MaxLength(10)]
    [JsonPropertyName("descricao")]
    public string Description { get; init; }

    [JsonPropertyName("RealizadaEm")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}