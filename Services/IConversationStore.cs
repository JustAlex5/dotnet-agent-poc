using Microsoft.Extensions.AI;

namespace AgentAiDemo.API.Services;

public interface IConversationStore
{
    List<ChatMessage> Get(string conversationId);
    void Save(string conversationId, List<ChatMessage> messages);
}