using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public UsersController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    [HttpPost,Route("create")]
    public async Task<ActionResult<UserDomainModel>> CreateAsync(UserDomainModel dto)
    {
        try
        {
            
            UserDomainModel user = dto;
            userLogic.saveAsync(user);
            return Created($"/users/{user.Id}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("findByUserName/{username}")]
    public async Task<ActionResult<UserDomainModel>> GetByUsernameAsync([FromRoute] string username)
    {
        Console.WriteLine("find called");
        try
        {
            UserDomainModel user = await userLogic.findByUsername(username);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("findByUserId")]
    public async Task<ActionResult<UserDomainModel>> GetById([FromQuery] int id)
    {
        Console.WriteLine("find called");
        try
        {
            UserDomainModel user = userLogic.findById(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDomainModel>>> GetAsync([FromQuery] string? username)
    {
        try
        {
            String parameters = new(username);
            UserDomainModel users = await userLogic.findByUsername(parameters);
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}