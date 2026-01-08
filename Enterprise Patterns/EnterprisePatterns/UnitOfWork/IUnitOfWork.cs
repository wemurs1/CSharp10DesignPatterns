namespace EnterprisePatterns.UnitOfWork;

public interface IUnitOfWork
{
    Task CommitAsync();
    void Rollback();
}
