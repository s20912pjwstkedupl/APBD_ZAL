using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZAL_APBD.Models;

public class Sale
{
    [Key]
    public int IdSale { get; set; }
    public int IdClient { get; set; }
    public int IdSubscription { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public virtual Sale VSale { get; set; }
    public virtual Client VClient { get; set; }
    public virtual Subscription VSubscription { get; set; }

}