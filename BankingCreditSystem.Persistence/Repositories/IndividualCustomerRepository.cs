using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Persistence.Contexts;

namespace BankingCreditSystem.Persistence.Repositories;

public class IndividualCustomerRepository : EfRepositoryBase<IndividualCustomer, Guid, BaseDbContext>, IIndividualCustomerRepository
{
    public IndividualCustomerRepository(BaseDbContext context) : base(context)
    {
    }
} 