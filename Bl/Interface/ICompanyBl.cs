using AgentAiDemo.API.Dto;

namespace AgentAiDemo.API.Bl.Interface;

public interface ICompanyBl
{
    Task<List<CompanyDto>> GetAllAsync();
    Task<List<CompanyDto>> SearchByNameAsync(string companyName);
    Task<CompanyDto?> GetByIdAsync(int id);

    Task<List<LinkedCompanyDto>> GetLinkedCompaniesAsync(int companyId);
    Task<List<TransactionDto>> GetTransactionsAsync(int companyId);
    Task<List<AddressDto>> GetAddressesAsync(int companyId);
}