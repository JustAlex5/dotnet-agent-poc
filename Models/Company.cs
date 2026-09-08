using System;
using System.Collections.Generic;

namespace AgentAiDemo.API.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Country { get; set; }

    public string? RegistrationNumber { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<CompanyRelation> CompanyRelationCompanies { get; set; } = new List<CompanyRelation>();

    public virtual ICollection<CompanyRelation> CompanyRelationLinkedCompanies { get; set; } = new List<CompanyRelation>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
