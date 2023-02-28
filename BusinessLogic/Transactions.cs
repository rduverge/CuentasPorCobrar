using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CuentasPorCobrar.Shared;

public class Transactions 
{
    public Transactions() 
    { 
        Documents = new HashSet<Document>();
    }
    [Key]
    public int TransactionId { get; set; }
    [Required]
    public string MovementType { get; set; } = null!;
    [Required]
    [ForeignKey("DocumentId")]
    public virtual ICollection<Document> Documents { get; set;} = null!;
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