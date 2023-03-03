using API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CuentasPorCobrar.Shared;
using FluentValidation;
using FluentValidation.Results;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository repo;
    private readonly IValidator<Customer> _validator;

    public CustomersController(ICustomerRepository repo, IValidator<Customer> _validator)
    {
        this.repo = repo;
        this._validator = _validator;
    }


    [HttpGet]
    [ProducesResponseType(200, Type=typeof(IEnumerable<Customer>))]
    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        return await repo.RetrieveAllAsync();
    }


    //GET: api/customers/[id]
    [HttpGet("{id}", Name =nameof(GetCustomerByID))]
    [ProducesResponseType(200, Type = typeof(Customer))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetCustomerByID(int id)
    {
        Customer? customer = await repo.RetrieveByIdAsync(id);

        return customer is null ? NotFound() : Ok(customer);
    }


    //Create a new customer
    //POST: api/customers
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Customer))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] Customer customer)
    {
        ValidationResult res = await _validator.ValidateAsync(customer);
        //if (customer is null) return BadRequest();

        if (!res.IsValid)
        {
            return BadRequest(res.Errors);
        }


        Customer? addedCustomer = await repo.CreateAsync(customer);

        return addedCustomer is null ? BadRequest("Error to save the customer.")
            : CreatedAtRoute(routeName:nameof(GetCustomerByID),
            routeValues: new {id = addedCustomer.CustomerId},
            value: addedCustomer);

    }


    //PUT: api/customers/[id]
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] Customer customer)
    {
        if(customer is null || customer.CustomerId != id) return BadRequest();

        Customer? existing = await repo.RetrieveByIdAsync(id);

        if (existing is null) return NotFound();
        await repo.UpdateAsync(id, customer);

        return new NoContentResult();
    }

    //DELETE: api/customers/[id]
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        Customer? existing = await repo.RetrieveByIdAsync(id);
        if(existing is null) return NotFound();

        bool? deleted = await repo.DeleteAsync(id);

        return deleted.HasValue && deleted.Value ?
            new NoContentResult()
            : BadRequest($"Customer number {id} was found but failed to delete");
    }
}
