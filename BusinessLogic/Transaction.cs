using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CuentasPorCobrar.Shared;

public class Transaction 
{
    public Transaction() 
    { 
        Documents = new HashSet<Document>();
        Customers = new HashSet<Customer>();
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
    public virtual ICollection<Customer> Customers { get; set; } = null!;
    [Required]
    [Column(TypeName ="money")]
    public decimal Amount { get; set; }
}