using Inventory.Application.DTOs.Customer;
using Inventory.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;



[ApiController]
[Route("api/[controller]")]
public class CustomersController(ICustomerService customerService): ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await customerService.GetAllCustomerAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await customerService.GetCustomerByIdAsync(id);
        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerDto dto)
    {
        var newCustomer = await customerService.CreateCustomerAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = newCustomer.Id }, newCustomer);
    }
    
    
    
    
    
    
}