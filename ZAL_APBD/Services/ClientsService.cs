using APBD_Z5.Repositories;
using Microsoft.IdentityModel.Tokens;
using ZAL_APBD.Dtos;
using ZAL_APBD.Exceptions;
using ZAL_APBD.Models;
using ZAL_APBD.Repositories;

namespace ZAL_APBD.Services;


public interface IClientsService
{
    public Task<ClientDto> GetOneById(int idClient);
}
public class ClientsService : IClientsService
{
    private IClientRepository _clientRepository;
    private IPaymentRepository _paymentRepository;
    private ISubscriptionRepository _subscriptionsRepository;

    public ClientsService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<ClientDto> GetOneById(int idClient)
    {
        var client = await _clientRepository.GetOneById(idClient);

        if (client == null)
        {
            throw new ClientNotFoundException();
        }

        // var subc = await _paymentRepository.GetForClient(idClient);
        return new ClientDto()
        {
            firstName = client.FirstName,
            lastName = client.LastName,
            email = client.Email,
            phone = client.Phone,
            // subscriptions = subc,
        };
    }
}