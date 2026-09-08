using AgentAiDemo.API.Dal.Interface;
using AgentAiDemo.API.Data;
using AgentAiDemo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentAiDemo.API.Dal;

public class CompanyDal(AppDbContext ctx) : ICompanyDal
{
    public async Task<List<Company>> GetAllAsync()
    {
        return await ctx.Companies
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Company>> GetAllByCompanyNameAsync(string companyName)
    {
        return await ctx.Companies
            .AsNoTracking()
            .Where(c => EF.Functions.ILike(c.Name, $"%{companyName}%"))
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Company?> GetCompanyByIdAsync(int id)
    {
        return await ctx.Companies
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<CompanyRelation>> GetLinkedCompaniesAsync(int companyId)
    {
        return await ctx.CompanyRelations
            .AsNoTracking()
            .Include(r => r.LinkedCompany)
            .Where(r => r.CompanyId == companyId)
            .OrderBy(r => r.LinkedCompany.Name)
            .ToListAsync();
    }
    
    public async Task<List<Transaction>> GetTransactionsAsync(int companyId)
    {
        return await ctx.Transactions
            .AsNoTracking()
            .Where(t => t.CompanyId == companyId)
            .ToListAsync();
    }
    
    public async Task<List<Address>> GetAddressesAsync(int companyId)
    {
        return await ctx.Addresses
            .AsNoTracking()
            .Where(a => a.CompanyId == companyId)
            .ToListAsync();
    }
    
    
}