using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APBD_Z5.Models;

namespace ZAL_APBD.Models;

public class Client
{
    [Key]
    public int IdClient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public virtual ICollection<Sale> VSales { get; set; }
    public virtual ICollection<Payment> VPayments { get; set; }
}