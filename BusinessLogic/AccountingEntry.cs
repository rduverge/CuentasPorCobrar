
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuentasPorCobrar.Shared;

public class AccountingEntry
{
     
    
    [Key]
    public int AccountingEntryId { get; set; }

    [StringLength(60)]
    [Required]
    public string Description { get; set; } = null!;


     
    //[ForeignKey("CustomerId")]
    //public virtual Customer? Customer { get; set; } = null!; 


    public int CustomerId { get; set;}
    public virtual Customer Customer { get; set; } = null!;


    [Required]
    [MaxLength(30)]
    public string Account { get; set; } = null!;


    [Required]
    public string MovementType { get; set; } = null!;

    [Column(TypeName= "timestamp without time zone")]
    public DateTime AccountEntryDate { get; set; }

    [Column(TypeName ="money")]
    public decimal AccountEntryAmount { get; set;}

    public string State { get; set; } = null!; 

    

}

