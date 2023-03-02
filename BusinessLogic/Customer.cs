using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace CuentasPorCobrar.Shared;

public class Customer
{
    public Customer()
    {

        AccountingEntries=new HashSet<AccountingEntry>();
        Transactions=new HashSet<Transaction>(); 

    }
    [Key]
    public int CustomerId { get; set; }

    
    [MaxLength(32)]
    public string? Name { get; set; }

    
    [MaxLength(13)]
    public string? Identification { get; set; }


    [Column(TypeName = "money")]
    public decimal CreditLimit { get; set; }

    public string? State { get; set; }  

    public virtual ICollection<AccountingEntry> AccountingEntries{get; set;} 
    public virtual ICollection<Transaction> Transactions { get; set; }



}

