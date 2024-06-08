using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZAL_APBD.Models;

public class Discount
{
    [Key]
    public int IdDiscount { get; set; }
    public int Value { get; set; }
    public int IdSubscription { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    
    public virtual Subscription VSubscription { get; set; }
}