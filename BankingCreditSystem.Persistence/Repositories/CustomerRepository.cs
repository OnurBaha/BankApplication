using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Persistence.Contexts;

namespace BankingCreditSystem.Persistence.Repositories;

public class CustomerRepository : EfRepositoryBase<Customer, Guid, BaseDbContext>, ICustomerRepository
{
    public CustomerRepository(BaseDbContext context) : base(context)
    {
    }
} 