using Microsoft.EntityFrameworkCore;
using ZAL_APBD.Dtos;
using ZAL_APBD.Models;

namespace APBD_Z5.Repositories;

public interface IClientRepository
{
    public Task<Client?> GetOneById(int idClient);
}

public class ClientRepository : IClientRepository
{
    private readonly SQLDBContext context;

    public ClientRepository(SQLDBContext context)
    {
        this.context = context;
    }

    public async Task<Client?> GetOneById(int idClient)
    {
        return await context.Clients.FirstOrDefaultAsync(client => client.IdClient == idClient);
    }
}