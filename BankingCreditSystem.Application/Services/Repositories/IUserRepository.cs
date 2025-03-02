using BankingCreditSystem.Core.Security.Entities;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User, Guid>
{
} 