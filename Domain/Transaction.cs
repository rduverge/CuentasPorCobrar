
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CuentasPorCobrar.Shared;

public class Transaction 
{
   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TransactionId { get; set; }
    
    public MovementTypes? MovementType { get; set; }

    public Guid DocumentId { get; set; }
    public virtual Document? Document { get; set; } 
    
    
    
    public Guid? DocumentNumber { get; set; }

    
    [Column(TypeName = "timestamp without time zone")]
    public DateTime TransactionDate { get; set; }


    public Guid CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }

   
    [Column(TypeName ="money")]
    public decimal Amount { get; set; }
}