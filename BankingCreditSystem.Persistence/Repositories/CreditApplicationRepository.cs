using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Persistence.Contexts;

namespace BankingCreditSystem.Persistence.Repositories;

public class CreditApplicationRepository : EfRepositoryBase<CreditApplication, Guid, BaseDbContext>, ICreditApplicationRepository
{
    public CreditApplicationRepository(BaseDbContext context) : base(context)
    {
    }
} 