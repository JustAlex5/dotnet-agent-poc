using AgentAiDemo.API.Dto;
using AgentAiDemo.API.Models;

namespace AgentAiDemo.API.Mapper;

public static class CompanyMapper
{
    public static CompanyDto ToDto(this Company company)
    {
        return new CompanyDto()
        {
            CompanyId = company.Id,
            Name = company.Name,
            Country = company.Country,
            RegistrationNumber = company.RegistrationNumber,
            Status = company.Status
        };
    }

    public static Company ToEntity(this CompanyDto dto)
    {
        return new Company()
        {
            Id = dto.CompanyId,
            Name = dto.Name,
            Country = dto.Country,
            RegistrationNumber = dto.RegistrationNumber,
            Status = dto.Status
        };
    }

    public static List<CompanyDto> ToDtoList(this IEnumerable<Company> companies)
    {
        return companies.Select(ToDto).ToList();
    }
    
    public static List<Company> ToEntityList(this List<CompanyDto> dtos)
    {
        return dtos.Select(ToEntity).ToList();
    }
}