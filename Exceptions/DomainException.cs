namespace RinhaBackend2024Q1.Exceptions;

public class DomainException(string? message) : Exception(message)
{
    public static void ThrowInsufficientLimit()
    {
        throw new DomainException("Insufficient limit");
    }
}