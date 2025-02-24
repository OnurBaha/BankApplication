namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;

public class UpdatedCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = default!;
    public string AuthorizedPersonName { get; set; } = default!;
    public DateTime UpdatedDate { get; set; }
    public string Message { get; set; } = default!;
} 