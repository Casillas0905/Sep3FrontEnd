using Application.LogicInterfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class UserInEventsController : ControllerBase
{

    private readonly IUserInEventLogic userInEventLogic;

    public UserInEventsController(IUserInEventLogic userInEventLogic)
    {
        this.userInEventLogic = userInEventLogic;
    }
    
    
    [HttpDelete, Route("deleteUser")]
    public void DeleteAsync(UserInEventDomainModel dto)
    {
        try
        {
           userInEventLogic.deleteUser(dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            StatusCode(500, e.Message);
        }
    }
    
    [HttpPost,Route("create")]
    public async Task<ActionResult<UserInEventDomainModel>> CreateAsync(UserInEventDomainModel dto)
    {
        try
        {
            UserInEventDomainModel user = dto;
            userInEventLogic.saveUsersInEvents(user);
            return Created($"/users/{user.id}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("findByUserId")]
    public async Task<ActionResult<IEnumerable<UserInEventDomainModel>>> GetByUserIdAsync([FromQuery] int id)
    {
        try
        {
            Task<IEnumerable<UserDomainModel>> users = userInEventLogic.findAllUsersForOneEvent(id);
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}