using Microsoft.AspNetCore.Mvc;
using Planner.Application.Application.DTOs;
using Planner.Application.Interface;
using Planner.Domain.Domain.Helpers.Extensions;

namespace Planner.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalendarController : ApiBaseController
{
    private readonly ICalendarApplicationService _service;

    public CalendarController(ICalendarApplicationService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("create-calendar")]
    public async Task<IActionResult> CreateCalendarAsync([FromBody] CalendarDto calendar)
    {
        var result = await _service.CreateAsync(calendar);

        if (result.IsSuccess())
        {
            return Ok(result.GetSuccessResult());
        }

        return BadRequest(result.GetErrorResult());
    }
}