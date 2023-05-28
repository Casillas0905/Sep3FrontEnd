using Application.LogicInterfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatLogic chatLogic;

    public ChatController(IChatLogic chatLogic)
    {
        this.chatLogic = chatLogic;
    }
    
    [HttpGet, Route("findById")]
    public async Task<ActionResult<ChatDomainModel>> GetByIdAsync([FromQuery] int id)
    {
        try
        {
            ChatDomainModel chat = chatLogic.findById(id);
            return Ok(chat);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("findByUserId")]
    public async Task<ActionResult<ChatDomainModel>> GetByUserIdAsync([FromQuery] int id)
    {
        try
        {
            Task<IEnumerable<ChatDomainModel>> chat = chatLogic.findByUserId(id);
            return Ok(chat);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete, Route("deleteChat")]
    public async Task<ActionResult<ChatDomainModel>> DeleteAsync([FromQuery] int id)
    {
        try
        {
            ChatDomainModel chat = chatLogic.findById(id);
            chatLogic.deleteChat(id);
            return Ok($"/delete/{chat.id}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}