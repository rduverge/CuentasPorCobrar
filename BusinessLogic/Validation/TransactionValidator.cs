

using CuentasPorCobrar.Shared;
using FluentValidation;

namespace BusinessLogic.Validation;

public class TransactionValidator:AbstractValidator<Transaction>
{
   public TransactionValidator()
    {
        RuleFor(t => t.DocumentNumber)
            .NotEmpty()
            .WithMessage("It cannot be empty!");

        RuleFor(t => t.Amount)
            .GreaterThan(0)
            .WithMessage("It cannot negative")
            .NotEmpty()
            .WithMessage("It cannot be empty"); 
            
            
    }
    
}