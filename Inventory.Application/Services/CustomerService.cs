using FluentValidation;
using Inventory.Application.DTOs.Customer;
using Inventory.Application.Extensions;
using Inventory.Application.Interfaces;
using Inventory.Domain.Entites;
using Inventory.Domain.Interfaces;
using MapsterMapper;

namespace Inventory.Application.Services;

public class CustomerService(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IValidator<CreateCustomerDto> createValidator,
    IValidator<UpdateCustomerDto> updateValidator
    ) : ICustomerService
{
    public async Task<CustomerResultDto> CreateCustomerAsync(CreateCustomerDto dto)
    {
        await createValidator.ValidateAndThrowAsync(dto);
        var category = Customer.Create(dto.FirstName, dto.LastName, dto.Email, dto.Phone);
        await customerRepository.AddAsync(category);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<CustomerResultDto>(category);
    }

    public async Task<IEnumerable<CustomerResultDto>> GetAllCustomerAsync()
    {
        var customers = await customerRepository.GetAsync(tracked: false);
        return mapper.Map<IEnumerable<CustomerResultDto>>(customers);
    }

    public async Task<CustomerResultDto> GetCustomerByIdAsync(int id)
    {
        var customer = await customerRepository.GetByOrThrowAsync(id, "Customer");
        return mapper.Map<CustomerResultDto>(customer);
    }

    public async Task UpdateCustomerAsync(int id, UpdateCustomerDto dto)
    {
        await updateValidator.ValidateAndThrowAsync(dto);
        var customer = await customerRepository.GetByOrThrowAsync(id, "Customer");
        
        customer.Update(dto.FirstName, dto.LastName, dto.Email, dto.Phone);
        customerRepository.Update(customer);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await customerRepository.GetByOrThrowAsync(id, "Customer");
        customerRepository.Remove(customer);
        await unitOfWork.SaveChangesAsync();
    }
}