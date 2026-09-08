using AgentAiDemo.API.Models;

namespace AgentAiDemo.API.Dal.Interface;

public interface ICompanyDal
{
    Task<List<Company>> GetAllAsync();

    Task<List<Company>> GetAllByCompanyNameAsync(string companyName);

    Task<Company?> GetCompanyByIdAsync(int companyId);

    Task<List<CompanyRelation>> GetLinkedCompaniesAsync(int companyId);

    Task<List<Transaction>> GetTransactionsAsync(int companyId);

    Task<List<Address>> GetAddressesAsync(int companyId);
}