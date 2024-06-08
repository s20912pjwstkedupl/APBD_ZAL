using Microsoft.AspNetCore.Mvc;
using ZAL_APBD.Services;

namespace ZAL_APBD.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientsService _clientsService;
    
    public ClientsController(IClientsService clientsService)
    {
        _clientsService = clientsService;
    }
    
    [HttpGet("{idClient}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetById([FromRoute] int idClient)
    {
        try
        {
            var client = await _clientsService.GetOneById(idClient);
            return Ok(client);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}