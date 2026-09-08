namespace AgentAiDemo.API.Dto;

public class LinkedCompanyDto
{
    public int CompanyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Country { get; set; }

    public string? RegistrationNumber { get; set; }

    public string RelationType { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsActive { get; set; }
}