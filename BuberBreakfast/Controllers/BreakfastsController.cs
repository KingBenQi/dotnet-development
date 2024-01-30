using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("breakfasts")]
public class BreakfastsController: ControllerBase
{
    [HttpPost()]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );    //mapping the data from the request
        
            

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDataTime,
            breakfast.Savory,
            breakfast.Sweet
        );//take the data back from our system and convert it back to the API def 

        return CreatedAtAction(
            actionName: nameof(request),
            routeValues: new{id = breakfast.Id},
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        return Ok(id);
    }
    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok(id);
    }

}