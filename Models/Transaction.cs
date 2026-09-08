using System;
using System.Collections.Generic;

namespace AgentAiDemo.API.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = null!;

    public DateOnly TransactionDate { get; set; }

    public string? Description { get; set; }

    public virtual Company Company { get; set; } = null!;
}
