using Application.LogicInterfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchController : ControllerBase
{
    private readonly IMatchLogic matchLogic;

    public MatchController(IMatchLogic matchLogic)
    {
        this.matchLogic = matchLogic;
    }

    [HttpPatch, Route("update")]
    public async Task<ActionResult<MatchDomainModel>> UpdateAsync(MatchDomainModel matchDomainModel)
    {
        try
        {
            matchLogic.updateMatch(matchDomainModel);
            return Created($"/match/{matchDomainModel.id}", matchDomainModel);
            
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("findById")]
    public async Task<ActionResult<MatchDomainModel>> GetByIdAsync([FromQuery] int id)
    {
        try
        {
           MatchDomainModel match = matchLogic.findById(id);
           return Ok(match);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("findByUserId")]
    public async Task<ActionResult<IEnumerable<MatchDomainModel>>> GetByUserIdAsync([FromQuery] int id)
    {
        try
        {
           Task<IEnumerable<MatchDomainModel>> match = matchLogic.findByUserId(id);
            return Ok(match);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete, Route("deleteMatch")]
    public async Task<ActionResult<MatchDomainModel>> DeleteAsync([FromQuery] int id)
    {
        try
        {
            MatchDomainModel match = matchLogic.findById(id);
            matchLogic.deleteMatch(id);
            return Ok($"/delete/{match.id}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}