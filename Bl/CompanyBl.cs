using AgentAiDemo.API.Bl.Interface;
using AgentAiDemo.API.Dal.Interface;
using AgentAiDemo.API.Dto;
using AgentAiDemo.API.Mapper;

namespace AgentAiDemo.API.Bl;

public class CompanyBl(ICompanyDal companyDal) : ICompanyBl
{
    public async Task<List<CompanyDto>> GetAllAsync()
    {
        var res = await companyDal.GetAllAsync();
        return res.ToDtoList();
    }

    public async Task<List<CompanyDto>> SearchByNameAsync(string companyName)
    {
        var res = await companyDal.GetAllByCompanyNameAsync(companyName);
        return res.ToDtoList();
    }

    public async Task<CompanyDto?> GetByIdAsync(int id)
    {
        var res = await companyDal.GetCompanyByIdAsync(id);
        return res?.ToDto();
    }
    
    public async Task<List<LinkedCompanyDto>> GetLinkedCompaniesAsync(int companyId)
    {
        var res = await companyDal.GetLinkedCompaniesAsync(companyId);
        return res.ToLinkedCompanyDtoList();
    }

    public async Task<List<TransactionDto>> GetTransactionsAsync(int companyId)
    {
        var res = await companyDal.GetTransactionsAsync(companyId);
        return res.ToDtoList();
    }

    public async Task<List<AddressDto>> GetAddressesAsync(int companyId)
    {
        var res = await companyDal.GetAddressesAsync(companyId);
        return res.ToDtoList();
    }
}