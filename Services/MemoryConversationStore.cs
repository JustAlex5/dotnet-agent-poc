using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Memory;

namespace AgentAiDemo.API.Services;

public class MemoryConversationStore(IMemoryCache cache)
    : IConversationStore
{
    
    public List<ChatMessage> Get(string conversationId)
    {
        return cache.Get<List<ChatMessage>>(conversationId) ?? [];
    }

    public void Save(
        string conversationId,
        List<ChatMessage> messages)
    {
        cache.Set(
            conversationId,
            messages,
            TimeSpan.FromHours(1));
    }
}