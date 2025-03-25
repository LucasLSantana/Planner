using Planner.Application.Application.DTOs;
using Planner.Application.Interface;
using Planner.Domain.Domain.Entities;
using Planner.Domain.Domain.Interfaces.Services;

namespace Planner.Application.Application;

public class UserApplicationService : IUserApplicationService
{
    private readonly IUserService _userService;

    public UserApplicationService(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Guid> CreateAsync(UserDto userDto)
    {
        try
        {
            var entity = User.New(userDto.Name, userDto.Email, userDto.Password, userDto.Admin);
            return await _userService.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateAsync(UserDto user)
    {
        try
        {
            var entity = await _userService.GetByIdAsync(user.Id);
            entity.UpdateNameEmail(user.Name, user.Email);
            await _userService.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    public async Task UpdateResetPasswordAsync(UserDto user)
    {
        try
        {
            var entity = await _userService.GetByIdAsync(user.Id);
            entity.UpdatePassword(user.Password);
            await _userService.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    public async Task UpdateUserAdminAsync(UserDto user)
    {
        try
        {
            var entity = await _userService.GetByIdAsync(user.Id);
            entity.UpdateAdmin(user.Admin);
            await _userService.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    public async Task UpdateUserActiveAsync(UserDto user)
    {
        try
        {
            var entity = await _userService.GetByIdAsync(user.Id);
            entity.UpdateActive(user.Active);
            await _userService.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task DeleteAsync(Guid userId)
    {
        try
        {
            await _userService.DeleteAsync(userId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<User> GetByIdAsync(Guid userId)
    {
        try
        {
            return await _userService.GetByIdAsync(userId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        try
        {
            return await _userService.AsQueryable();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }   
    }
    
    public async Task<User> GetUserByNameAsync(string name)
    {
        try
        {
            return await _userService.FindWithPredicate(a => a.Name == name);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }   
    }
    
    public async Task<User> GetUserByEmailAsync(string email)
    {
        try
        {
            return await _userService.FindWithPredicate(a => a.Email == email);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }   
    }

    public async Task<IEnumerable<User>> GetUsersActiveAsync()
    {
        try
        {
            return await _userService.FindListWithPredicate(a => a.Active);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
