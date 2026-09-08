namespace AgentAiDemo.API.Dto;

public class CompanyRelationDto
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public int LinkedCompanyId { get; set; }

    public string RelationType { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsActive { get; set; }

    public CompanyDto? LinkedCompany { get; set; }
}