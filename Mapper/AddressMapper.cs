using AgentAiDemo.API.Dto;
using AgentAiDemo.API.Models;

namespace AgentAiDemo.API.Mapper;

public static class AddressMapper
{
    public static AddressDto ToDto(this Address address)
    {
        return new AddressDto
        {
            Id = address.Id,
            CompanyId = address.CompanyId,
            Country = address.Country,
            City = address.City,
            Street = address.Street,
            IsPrimary = address.IsPrimary
        };
    }

    public static List<AddressDto> ToDtoList(
        this IEnumerable<Address> addresses)
    {
        return addresses
            .Select(a => a.ToDto())
            .ToList();
    }
}