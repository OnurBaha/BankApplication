namespace BankingCreditSystem.Core.Application.Authorization;

public interface ISecuredRequest
{
    string[] Roles { get; }
} 