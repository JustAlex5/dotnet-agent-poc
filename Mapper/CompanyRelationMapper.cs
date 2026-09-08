using AgentAiDemo.API.Dto;
using AgentAiDemo.API.Models;

namespace AgentAiDemo.API.Mapper;

public static class CompanyRelationMapper
{
    public static LinkedCompanyDto ToLinkedCompanyDto(this CompanyRelation relation)
    {
        return new LinkedCompanyDto
        {
            CompanyId = relation.LinkedCompanyId,
            Name = relation.LinkedCompany.Name,
            Country = relation.LinkedCompany.Country,
            RegistrationNumber = relation.LinkedCompany.RegistrationNumber,
            RelationType = relation.RelationType,
            StartDate = relation.StartDate,
            EndDate = relation.EndDate,
            IsActive = relation.IsActive
        };
    }

    public static List<LinkedCompanyDto> ToLinkedCompanyDtoList(
        this IEnumerable<CompanyRelation> relations)
    {
        return relations
            .Select(r => r.ToLinkedCompanyDto())
            .ToList();
    }
}