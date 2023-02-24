namespace CuentasPorCobrar.Shared;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Document
{
    [Key]
    public int DocumentId { get; set; }


    [Required]
    [MaxLength(50)]
    public string Description { get; set; } = null!;


    [Required]
    [MaxLength(40)]
    public string LedgerAccount { get; set; } = null!;


    public bool IsAvailable { get; set;}

}

