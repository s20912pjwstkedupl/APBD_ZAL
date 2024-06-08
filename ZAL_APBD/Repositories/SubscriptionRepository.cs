using Microsoft.EntityFrameworkCore;
using ZAL_APBD.Dtos;
using ZAL_APBD.Models;

namespace APBD_Z5.Repositories;

public interface ISubscriptionRepository
{
    // public Task<List<Subscription>> GetForClient(int idClient);
}

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly SQLDBContext context;

    public SubscriptionRepository(SQLDBContext context)
    {
        this.context = context;
    }

    // public async Task<List<SubscriptionDto>> GetForClient(int idClient)
    // {
    //     return await context.Subscriptions.Where(u => u != "")
    // }
}