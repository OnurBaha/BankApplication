namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;

public class CreatedCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public string CompanyRegistrationNumber { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
    public string Message { get; set; } = default!;
} 