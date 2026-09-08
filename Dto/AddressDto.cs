namespace AgentAiDemo.API.Dto;

public class AddressDto
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public bool IsPrimary { get; set; }
}