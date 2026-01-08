using EnterprisePatterns.Entities;
using EnterprisePatterns.Repositories;

namespace EnterprisePatterns.Services;

public class RepositoryDemoService(IRepository<Order> genericOrderRepository)
{
    private readonly IRepository<Order> _genericOrderRepository = genericOrderRepository;

    public async Task RunAsync()
    {
        // load order
        var order = await _genericOrderRepository.Get(1);

        if (order != null)
        {
            // update order
            order.Description = "Updated Description";
            // save changes
            await _genericOrderRepository.SaveChanges();
        }
    }
}
