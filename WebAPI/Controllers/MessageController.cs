using Application.LogicInterfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageLogic messageLogic;

    public MessageController(IMessageLogic messageLogic)
    {
        this.messageLogic = messageLogic;
    }
    
    [HttpDelete, Route("deleteMessage")]
    public async Task<ActionResult<MessageDomainModel>> DeleteAsync([FromQuery] int id)
    {
        try
        {
            MessageDomainModel message = messageLogic.findById(id);
            messageLogic.deleteMessage(id);
            return Ok($"/delete/{message.id}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("findByChatId")]
    public async Task<ActionResult<IEnumerable<MessageDomainModel>>> GetByChatIdAsync([FromQuery] int id)
    {
        try
        {
            Task<IEnumerable<MessageDomainModel>> messages = messageLogic.findAllMessagesForAChat(id);
            return Ok(messages);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("findById")]
    public async Task<ActionResult<MessageDomainModel>> GetByIdAsync([FromQuery] int id)
    {
        try
        {
            MessageDomainModel message = messageLogic.findById(id);
            return Ok(message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost,Route("create")]
    public async Task<ActionResult<MessageDomainModel>> CreateAsync(MessageDomainModel dto)
    {
        try
        {
            MessageDomainModel messages = dto;
            messageLogic.saveMessage(messages);
            return Created($"/users/{messages.id}", messages);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}