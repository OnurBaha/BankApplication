namespace BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

public class DeletedIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string Message { get; set; } = default!;
} 