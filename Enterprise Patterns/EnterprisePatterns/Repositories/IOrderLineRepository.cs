using EnterprisePatterns.Entities;

namespace EnterprisePatterns.Repositories;

public interface IOrderLineRepository
{
    Task<OrderLine?> Get(int id);
    Task<IEnumerable<OrderLine>> GetAll();
    Task<IEnumerable<OrderLine>> GetAllByOrderId(int orderId);
    void Add(OrderLine entity);
    void Delete(OrderLine entity);
    void Update(OrderLine entity);
    Task SaveChanges();
}
