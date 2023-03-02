namespace CuentasPorCobrar.Shared;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Document
{
    public Document()
    {
        Transactions=new HashSet<Transaction>();
    }
    [Key]
    public int DocumentId { get; set; }


   
    [MaxLength(50)]
    public string? Description { get; set; }


    
    [MaxLength(40)]
    public string? LedgerAccount { get; set; }


    public string State { get; set;}

    public virtual ICollection<Transaction> Transactions { get; set; }

}

