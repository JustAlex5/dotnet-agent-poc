namespace AgentAiDemo.API.Models;

public class AgentQueryRequest
{
    public required string ConversationId { get; set; }
    public required string Query { get; set; }
}