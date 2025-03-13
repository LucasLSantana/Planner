using Microsoft.AspNetCore.Mvc;
using Planner.Application.Application.DTOs;
using Planner.Application.Interface;

namespace Planner.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ApiBaseController
{
    private readonly IUserApplicationService _service;

    public UserController(IUserApplicationService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("create-user")]
    public async Task<IActionResult> CreateUserAsync([FromBody] UserDto user)
    {
        await _service.CreateAsync(user);
        return Ok();
    }
    
    [HttpPut]
    [Route("update-user")]
    public async Task<IActionResult> UpdateUserAsync([FromBody] UserDto user)
    {
        await _service.UpdateAsync(user);
        return Ok();
    }

    [HttpPut]
    [Route("update-reset-password")]
    public async Task<IActionResult> UpdateResetPasswordAsync([FromBody] UserDto user)
    {
        await _service.UpdateResetPasswordAsync(user);
        return Ok();
    }
    
    [HttpPut]
    [Route("update-user-to-admin")]
    public async Task<IActionResult> UpdateUserAdminAsync([FromBody] UserDto user)
    {
        await _service.UpdateUserAdminAsync(user);
        return Ok();
    }
    
    [HttpPut]
    [Route("update-user-active")]
    public async Task<IActionResult> UpdateUserActiveAsync([FromBody] UserDto user)
    {
        await _service.UpdateUserActiveAsync(user);
        return Ok();
    }

    [HttpDelete]
    [Route("delete-user")]
    public async Task<IActionResult> DeleteUserAsync([FromBody] Guid userId)
    {
        await _service.DeleteAsync(userId);
        return Ok();
    }

    [HttpGet]
    [Route("get-user")]
    public async Task<IActionResult> GetUserAsync([FromBody] Guid userId)
    {
        var user = await _service.GetByIdAsync(userId);
        return Ok(user);
    }

    [HttpGet]
    [Route("get-users")]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await _service.GetUsersAsync();
        return Ok(users);
    }

    [HttpGet]
    [Route("get-users-by-name")]
    public async Task<IActionResult> GetUsersByNameAsync(string name)
    {
        var user = await _service.GetUserByNameAsync(name);
        return Ok(user);
    }

    [HttpGet]
    [Route("get-users-by-email")]
    public async Task<IActionResult> GetUsersByEmailAsync(string email)
    {
        var user = await _service.GetUserByEmailAsync(email);
        return Ok(user);
    }

    [HttpGet]
    [Route("get-users-active")]
    public async Task<IActionResult> GetUsersActiveAsync()
    {
        var user = await _service.GetUsersActiveAsync();
        return Ok(user);
    }
}
