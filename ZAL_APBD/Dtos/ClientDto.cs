using System.Collections.ObjectModel;

namespace ZAL_APBD.Dtos;

public class ClientDto
{
    public ClientDto()
    {
        subscriptions = new List<SubscriptionDto>();
    }
    public string firstName { get; set; } 
    public string lastName { get; set; } 
    public string email { get; set; } 
    public string phone { get; set; } 
    public IEnumerable<SubscriptionDto> subscriptions { get; set; } 
}

public class SubscriptionDto
{
    public int IdSubscription { get; set; }
    public string Name { get; set; }
    public int TotalPaidAmount { get; set; }
}