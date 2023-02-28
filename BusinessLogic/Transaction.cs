using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CuentasPorCobrar.Shared;

public class Transaction 
{
    public Transaction() 
    { 
       
    }
    [Key]
    public int TransactionId { get; set; }
    [Required]
    public string MovementType { get; set; } = null!;

    [ForeignKey("DocumentId")]
    public virtual Document? Document { get; set; } = null!; 
    
    
    [Required]
    public string DocumentNumber { get; set; } = null!;
    [Required]
    [Column(TypeName = "timestamp without time zone")]
    public DateTime TransactionDate { get; set; }



    [ForeignKey("CustomerId")]
    public virtual Customer? Customer { get; set; } = null!;

    [Required]
    [Column(TypeName ="money")]
    public decimal Amount { get; set; }
}