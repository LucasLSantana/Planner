using Planner.Application.Application;
using Planner.Application.Application.DTOs;
using Planner.Application.Extensions;
using Planner.Domain.Domain.Entities;
using System.Linq.Expressions;

namespace Planner.Application.Mappings.UserMapping;

public static class UserMapper
{
    public static UserDto MapEntityToDto(User user)
    {
        return new UserDto
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            Admin = user.Admin
        };
    }

    public static Expression<Func<User, UserDto>> Expression(IMap<User, UserDto> arg)
    {
        Expression<Func<User, UserDto>> expression = user => new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            Admin = user.Admin
        };
        return expression;
    }
}
