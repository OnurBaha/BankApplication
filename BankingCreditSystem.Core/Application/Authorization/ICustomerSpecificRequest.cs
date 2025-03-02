namespace BankingCreditSystem.Core.Application.Authorization;

public interface ICustomerSpecificRequest
{
    Guid CustomerId { get; }
} 