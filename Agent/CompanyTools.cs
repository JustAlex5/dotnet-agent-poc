using AgentAiDemo.API.Bl.Interface;
using AgentAiDemo.API.Dto;

namespace AgentAiDemo.API.Agent;

public class CompanyTools(ICompanyBl companyBl, ILogger<CompanyTools> logger)
{
    public Task<List<CompanyDto>> SearchCompanyByNameAsync(string companyName)
    {
        logger.LogInformation(
            "Agent called SearchCompanyByNameAsync with {CompanyName}",
            companyName);
        return companyBl.SearchByNameAsync(companyName);
    }

    public Task<CompanyDto?> GetCompanyByIdAsync(int companyId)
    {
        return companyBl.GetByIdAsync(companyId);
    }

    public Task<List<LinkedCompanyDto>> GetLinkedCompaniesAsync(int companyId)
    {
        return companyBl.GetLinkedCompaniesAsync(companyId);
    }

    public Task<List<TransactionDto>> GetTransactionsAsync(int companyId)
    {
        return companyBl.GetTransactionsAsync(companyId);
    }

    public Task<List<AddressDto>> GetAddressesAsync(int companyId)
    {
        return companyBl.GetAddressesAsync(companyId);
    }
}