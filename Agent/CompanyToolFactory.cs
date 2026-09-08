using Microsoft.Extensions.AI;

namespace AgentAiDemo.API.Agent;

public static class CompanyToolFactory
{
    public static IList<AITool> Create(CompanyTools tools)
    {
        return
        [
            AIFunctionFactory.Create(
                tools.SearchCompanyByNameAsync,
                name: "search_company_by_name",
                description:
                    """
                    Searches companies by partial company name.

                    Use this when the user provides a company name
                    but the internal company ID is unknown.

                    The function may return multiple companies.
                    If multiple plausible matches are returned,
                    do not choose one arbitrarily.
                    Ask the user to clarify which company they mean.
                    
                    IMPORTANT:
                    - companyId is the internal Id returned by search_company_by_name.
                    - Do NOT use RegistrationNumber as companyId.
                    - If you only know the company name, first call search_company_by_name.
                    """
            ),

            AIFunctionFactory.Create(
                tools.GetCompanyByIdAsync,
                name: "get_company_by_id",
                description:
                    """
                    Returns a company using its internal company ID.
                    
                    IMPORTANT:
                    - companyId is the internal Id returned by search_company_by_name.
                    - Do NOT use RegistrationNumber as companyId.
                    - If you only know the company name, first call search_company_by_name.
                    """
            ),

            AIFunctionFactory.Create(
                tools.GetLinkedCompaniesAsync,
                name: "get_linked_companies",
                description:
                    """
                    Returns companies linked to the specified company.

                    Requires an internal company ID.
                    If only a company name is known, first call
                    search_company_by_name.
                    """
            ),

            AIFunctionFactory.Create(
                tools.GetTransactionsAsync,
                name: "get_company_transactions",
                description:
                    """
                    Returns transactions belonging to the specified company.
                    Requires an internal company ID.
                    """
            ),

            AIFunctionFactory.Create(
                tools.GetAddressesAsync,
                name: "get_company_addresses",
                description:
                    """
                    Returns addresses belonging to the specified company.
                    Requires an internal company ID.
                    """
            )
        ];
    }
}