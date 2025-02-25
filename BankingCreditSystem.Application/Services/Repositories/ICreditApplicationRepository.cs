using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface ICreditApplicationRepository : IAsyncRepository<CreditApplication, Guid>
{
} 