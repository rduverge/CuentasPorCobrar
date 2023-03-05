
namespace CuentasPorCobrar.Shared;

public interface ICustomerRepository
{
    Task<Customer?> CreateAsync(Customer customer);
    Task<IEnumerable<Customer>> RetrieveAllAsync();
    Task<Customer?> RetrieveByIdAsync(Guid id);
    Task<Customer?> UpdateAsync(Guid id, Customer customer);
    Task<bool?> DeleteAsync(Guid id);
}