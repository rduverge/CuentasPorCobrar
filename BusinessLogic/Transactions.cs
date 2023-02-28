using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuentasPorCobrar.Shared;

public class Transactions 
{
    [Key]
    public int TransactionId { get; set; }
    [Required]
    public string MovementType { get; set; } = null!;
    [Required]
    [ForeignKey("DocumentId")]
    public virtual Document Document { get; set;} = null!;
    [Required]
    public string DocumentNumber { get; set; } = null!;
    [Required]
    [Column(TypeName ="datetime")]
    public DateTime TransactionDate { get; set; }
    [Required]
    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; } = null!;
    [Required]
    [Column(TypeName ="money")]
    public decimal Amount { get; set; }
}