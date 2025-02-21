namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;

public class CreateCorporateCustomerRequest
{
    public string CompanyName { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public string TaxOffice { get; set; } = default!;
    public string CompanyRegistrationNumber { get; set; } = default!;
    public string AuthorizedPersonName { get; set; } = default!;
    public DateTime CompanyFoundationDate { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
} 