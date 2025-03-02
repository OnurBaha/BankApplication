using BankingCreditSystem.Core.Security;

namespace BankingCreditSystem.Application.Features.Auth.Dtos;

public class LoginResponse
{
    public AccessToken AccessToken { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
} 