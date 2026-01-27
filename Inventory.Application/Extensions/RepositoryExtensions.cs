using Inventory.Domain.Interfaces;

namespace Inventory.Application.Extensions;

public static class RepositoryExtensions
{
    public static async Task<T> GetByOrThrowAsync<T>(
    this IRepository<T> repository,
    int id,
    string entityName) where T : class
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new KeyNotFoundException($"{entityName} con el id {id} no encontrado");

        return entity;
    }
    
    
    
    
}