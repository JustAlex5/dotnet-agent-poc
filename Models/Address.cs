using System;
using System.Collections.Generic;

namespace AgentAiDemo.API.Models;

public partial class Address
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public bool IsPrimary { get; set; }

    public virtual Company Company { get; set; } = null!;
}
