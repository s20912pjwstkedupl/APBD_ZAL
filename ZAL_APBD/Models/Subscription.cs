using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using APBD_Z5.Models;

namespace ZAL_APBD.Models;

public class Subscription
{
    [Key]
    public int IdSubscription { get; set; }
    public string Name { get; set; }
    public int RenewalPeriod { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Price { get; set; }
    
    public virtual ICollection<Discount> VDiscounts { get; set; }
    public virtual ICollection<Sale> VSales { get; set; }
    public virtual ICollection<Payment> VPayments { get; set; }


}