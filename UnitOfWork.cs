using System.Data;

namespace RinhaBackend2024Q1;

public sealed class UnitOfWork
{
    private readonly IDbConnection _dbConnection;
    private IDbTransaction _dbTransaction = null!;

    public UnitOfWork(IDbConnection dbConnection)
    {
        dbConnection.Open();
        _dbConnection = dbConnection;
    }

    public void BeginTransaction()
    {
        _dbTransaction = _dbConnection.BeginTransaction();
    }

    public void BeginTransaction(IsolationLevel isolationLevel)
    {
        _dbTransaction = _dbConnection.BeginTransaction(isolationLevel);
    }

    public void Commit()
    {
        _dbTransaction.Commit();
    }

    public void Rollback()
    {
        _dbTransaction.Rollback();
    }
}