using BankingCreditSystem.Core.Security.Entities;

namespace BankingCreditSystem.Core.Security;

public interface ITokenHelper
{
    Task<AccessToken> CreateToken(User user);
    string GetUserIdFromToken(string token);
} 