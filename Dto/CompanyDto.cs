namespace AgentAiDemo.API.Dto;

public class CompanyDto
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string? Country { get; set; }
    public string? RegistrationNumber { get; set; }
    public string? Status { get; set; }
}