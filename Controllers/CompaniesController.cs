using AgentAiDemo.API.Bl.Interface;
using AgentAiDemo.API.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AgentAiDemo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController(ICompanyBl companyBl) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CompanyDto>>> GetAll()
    {
        var companies = await companyBl.GetAllAsync();
        return Ok(companies);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<CompanyDto>>> Search(
        [FromQuery] string search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return BadRequest("Search value is required.");

        var companies = await companyBl.SearchByNameAsync(search);
        return Ok(companies);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CompanyDto>> GetById(int id)
    {
        var company = await companyBl.GetByIdAsync(id);

        if (company is null)
            return NotFound();

        return Ok(company);
    }

    [HttpGet("{id:int}/linked")]
    public async Task<ActionResult<List<LinkedCompanyDto>>> GetLinkedCompanies(
        int id)
    {
        var companies = await companyBl.GetLinkedCompaniesAsync(id);
        return Ok(companies);
    }

    [HttpGet("{id:int}/transactions")]
    public async Task<ActionResult<List<TransactionDto>>> GetTransactions(
        int id)
    {
        var transactions = await companyBl.GetTransactionsAsync(id);
        return Ok(transactions);
    }

    [HttpGet("{id:int}/addresses")]
    public async Task<ActionResult<List<AddressDto>>> GetAddresses(
        int id)
    {
        var addresses = await companyBl.GetAddressesAsync(id);
        return Ok(addresses);
    }
}