using Inventory.Application.DTOs.Customer;

namespace Inventory.Application.Interfaces;

public interface ICustomerService
{
    Task<CustomerResultDto> CreateCustomerAsync(CreateCustomerDto dto);
    Task<IEnumerable<CustomerResultDto>> GetAllCustomerAsync();
    Task<CustomerResultDto> GetCustomerByIdAsync(int id);
    Task UpdateCustomerAsync(int id, UpdateCustomerDto dto);
    Task DeleteCustomerAsync(int id);

}