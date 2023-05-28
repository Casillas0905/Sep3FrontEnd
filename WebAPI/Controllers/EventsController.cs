using Application.LogicInterfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventLogic eventLogic;

    public EventsController(IEventLogic eventLogic)
    {
        this.eventLogic = eventLogic;
    }
    
    [HttpGet, Route("findById")]
    public async Task<ActionResult<EventDomainModel>> GetByIdAsync([FromQuery] int id)
    {
        try
        {
            Task<EventDomainModel> events= eventLogic.findById(id);
            return Ok(events);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch, Route("update")]
    public async Task<ActionResult<EventDomainModel>> UpdateAsync(EventDomainModel eventDomainModel)
    {
        try
        {
            eventLogic.updateEvent(eventDomainModel);
            return Created($"/match/{eventDomainModel.id}", eventDomainModel);
            
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete, Route("deleteEvent")]
    public async Task<ActionResult<EventDomainModel>> DeleteAsync([FromQuery] int id)
    {
        try
        {
            Task<EventDomainModel> events = eventLogic.findById(id);
            eventLogic.deleteEvent(id);
            return Ok($"/delete/{events.Id}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost,Route("create")]
    public async Task<ActionResult<EventDomainModel>> CreateAsync(EventDomainModel dto)
    {
        try
        {
            
            EventDomainModel events = dto;
            eventLogic.saveEvent(events);
            return Created($"/users/{events.id}", events);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
}