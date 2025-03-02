using BankingCreditSystem.Core.Security;

namespace BankingCreditSystem.Application.Features.Auth.Dtos;

public class RegisterResponse
{
    public AccessToken AccessToken { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
} 