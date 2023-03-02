﻿
using BusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuentasPorCobrar.Shared;

public class AccountingEntry
{
     
    
    [Key]
    public int AccountingEntryId { get; set; }

    
    public string? Description { get; set; }


 


    public int CustomerId { get; set;}
    public virtual Customer? Customer { get; set; }


    
    
    public string? Account { get; set; }


    public MovementTypes? MovementType { get; set; } 

    [Column(TypeName= "timestamp without time zone")]
    public DateTime AccountEntryDate { get; set; }

    [Column(TypeName ="money")]
    public decimal AccountEntryAmount { get; set;}

    public States? State { get; set; } 

    

}

