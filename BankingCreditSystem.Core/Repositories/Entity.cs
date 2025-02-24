namespace BankingCreditSystem.Core.Repositories;

public abstract class Entity<TId> 
{
    public TId Id { get; set; } = default!;
    public DateTime CreatedDate { get; set; } 
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    protected Entity()
    {
        CreatedDate = DateTime.UtcNow;
    }
} 