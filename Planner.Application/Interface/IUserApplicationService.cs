using Planner.Application.Application.DTOs;
using Planner.Domain.Domain.Entities;

namespace Planner.Application.Interface;

public interface IUserApplicationService
{
    Task<Guid> CreateAsync(UserDto user);
    Task UpdateAsync(UserDto user);
    Task UpdateResetPasswordAsync(UserDto user);
    Task UpdateUserAdminAsync(UserDto user);
    Task UpdateUserActiveAsync(UserDto user);
    Task DeleteAsync(Guid id);
    Task<User> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserByNameAsync(string name);
    Task<User> GetUserByEmailAsync(string email);
    Task<IEnumerable<User>> GetUsersActiveAsync();
}