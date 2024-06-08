using System.Data.Entity;
using APBD_Z5.Models;
using Microsoft.EntityFrameworkCore;
using ZAL_APBD.Dtos;
using ZAL_APBD.Models;

namespace ZAL_APBD.Repositories;

public interface IPaymentRepository
{
    public Task<List<SubscriptionDto>> GetForClient(int idClient);
}

public class PaymentRepository : IPaymentRepository
{
    private readonly SQLDBContext context;

    public PaymentRepository(SQLDBContext context)
    {
        this.context = context;
    }

    public async Task<List<SubscriptionDto>> GetForClient(int idClient)
    {
        return await context.Payments.Where(u => u.IdClient == idClient).Select(p => new SubscriptionDto()
        {
            IdSubscription = p.IdSubscription,
            Name = p.VSubscription.Name,
            TotalPaidAmount = (int)p.VSubscription.Price - p.VSubscription.VDiscounts.Sum(d => d.Value)
        }).ToListAsync();
    }
}