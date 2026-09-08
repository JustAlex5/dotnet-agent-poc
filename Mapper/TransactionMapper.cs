using AgentAiDemo.API.Dto;
using AgentAiDemo.API.Models;

namespace AgentAiDemo.API.Mapper;

public static class TransactionMapper
{
    public static TransactionDto ToDto(this Transaction transaction)
    {
        return new TransactionDto
        {
            Id = transaction.Id,
            CompanyId = transaction.CompanyId,
            Amount = transaction.Amount,
            Currency = transaction.Currency,
            TransactionDate = transaction.TransactionDate,
            Description = transaction.Description
        };
    }

    public static List<TransactionDto> ToDtoList(
        this IEnumerable<Transaction> transactions)
    {
        return transactions
            .Select(t => t.ToDto())
            .ToList();
    }
}