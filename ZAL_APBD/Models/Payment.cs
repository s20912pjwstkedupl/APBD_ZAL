using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using ZAL_APBD.Models;

namespace APBD_Z5.Models;

public class Payment
{
    [Key]
    public int IdPayment { get; set; }
    public DateTime Date { get; set; }
    public int IdClient { get; set; }
    public int IdSubscription { get; set; }
    
    
    public virtual Client VClient { get; set; }
    public virtual Subscription VSubscription { get; set; }
}