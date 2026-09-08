using AgentAiDemo.API.Agent;
using AgentAiDemo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgentAiDemo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgentController(CompanyAgent agent) : ControllerBase
{
    [HttpPost("query")]
    public async Task<IActionResult> Query(
        AgentQueryRequest request,
        CancellationToken cancellationToken)
    {
        var result = await agent.AskAsync(
            request.ConversationId,
            request.Query,
            cancellationToken);

        return Ok(new
        {
            request.ConversationId,
            Answer = result
        });
    }
}

