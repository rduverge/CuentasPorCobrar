
namespace CuentasPorCobrar.Shared;

public interface IAccountingEntryRepository
{
 
    Task<AccountingEntry?> CreateAsync(AccountingEntry accountingEntry);
    Task<IEnumerable<AccountingEntry>> RetrieveAllAsync();
    Task<AccountingEntry?> RetrieveAsync(Guid id);
    Task<AccountingEntry?> UpdateAsync(Guid id, AccountingEntry accountingEntry);
   
    Task<bool?> DeleteAsync(Guid id); 

}

