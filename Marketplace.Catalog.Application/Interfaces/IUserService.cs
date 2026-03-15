using Marketplace.Catalog.Domain.Dtos;
using Marketplace.Catalog.Domain.Entities;

namespace Marketplace.Catalog.Application.interfaces;

public interface IUserService
{
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task CreateAsync(CreateUserRequest request);
}
