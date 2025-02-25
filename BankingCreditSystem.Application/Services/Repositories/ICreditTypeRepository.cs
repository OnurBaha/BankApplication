using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface ICreditTypeRepository : IAsyncRepository<CreditType, Guid>
{
} 