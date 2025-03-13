namespace Planner.Application.Application.DTOs;

public record UserDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool Admin { get; set; }
    public bool Active { get; set; }
}
