using Microsoft.EntityFrameworkCore;
using ZAL_APBD.Models;

namespace ZAL_APBD.Repositories;

public interface ISaleRepository
{
    // public Task<List<Sale>> GetForClient(int idClient);
}

public class SaleRepository : ISaleRepository
{
    private readonly SQLDBContext context;
    

    public SaleRepository(SQLDBContext context)
    {
        this.context = context;
    }

    // public async Task<List<Sale>> GetForClient(int idClient)
    // {
    //     return await context.Sales.FindAsync(row => row.IdClient == idClient);
    // }
}