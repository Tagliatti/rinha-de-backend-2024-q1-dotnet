using RinhaBackend2024Q1.Entities;
using RinhaBackend2024Q1.Repositories;
using RinhaBackend2024Q1.ValueObjects;

namespace RinhaBackend2024Q1.Services;

public class TransactionService(
    UnitOfWork unitOfWork,
    TransactionRepository transactionRepository,
    ClientRepository clientRepository
)
{
    public async Task<Client?> Handle(Transaction transaction)
    {
        unitOfWork.BeginTransaction();
        var client = await clientRepository.FindByIdForUpdateAsync(transaction.ClientId);

        if (client is null)
        {
            return null;
        }

        if (transaction.Type == 'c')
        {
            client.Credit(transaction.Amount);
        }
        else
        {
            client.Debit(transaction.Amount);
        }

        await clientRepository.UpdateBalanceAsync(client);

        await transactionRepository.CreateAsync(transaction);
        unitOfWork.Commit();

        return client;
    }
}