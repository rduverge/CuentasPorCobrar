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
   
    
    public int? DocumentId { get; set; }    
    public Document? Document { get; set; }
    
    [Required]
    public string DocumentNumber { get; set; } = null!;
    [Required]
    [Column(TypeName = "timestamp without time zone")]
    public DateTime TransactionDate { get; set; }
    

    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
   
    [Required]
    [Column(TypeName ="money")]
    public decimal Amount { get; set; }
}