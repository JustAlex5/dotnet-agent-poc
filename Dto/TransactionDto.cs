namespace AgentAiDemo.API.Dto;

public class TransactionDto
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = null!;

    public DateOnly TransactionDate { get; set; }

    public string? Description { get; set; }
}