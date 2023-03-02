
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuentasPorCobrar.Shared;

public class AccountingEntry
{
     
    
    [Key]
    public int AccountingEntryId { get; set; }

    [StringLength(60)]
    public string? Description { get; set; }


 


    public int CustomerId { get; set;}
    public virtual Customer? Customer { get; set; }


    
    [MaxLength(30)]
    public string? Account { get; set; }


    public string? MovementType { get; set; } 

    [Column(TypeName= "timestamp without time zone")]
    public DateTime AccountEntryDate { get; set; }

    [Column(TypeName ="money")]
    public decimal AccountEntryAmount { get; set;}

    public string? State { get; set; } 

    

}

