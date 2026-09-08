using System;
using System.Collections.Generic;

namespace AgentAiDemo.API.Models;

public partial class CompanyRelation
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public int LinkedCompanyId { get; set; }

    public string RelationType { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Company LinkedCompany { get; set; } = null!;
}
