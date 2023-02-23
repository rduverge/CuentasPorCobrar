using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace CuentasPorCobrar.Shared; 

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required]
    [MaxLength(32)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(13)]
    public string Identification { get; set; } = null!;


    [Column(TypeName ="money")]
    public decimal CreditLimit { get; set;}
     
    public bool IsAvailable { get; set;}


    
}

