using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Domain.Entities;

public abstract class Customer : Entity<Guid>
{
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
    public bool IsActive { get; set; }

    protected Customer()
    {
        IsActive = true;
    }
} 