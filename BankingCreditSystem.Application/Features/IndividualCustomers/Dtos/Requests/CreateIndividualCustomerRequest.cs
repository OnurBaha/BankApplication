namespace BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;

public class CreateIndividualCustomerRequest
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string NationalId { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string? MotherName { get; set; }
    public string? FatherName { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
} 