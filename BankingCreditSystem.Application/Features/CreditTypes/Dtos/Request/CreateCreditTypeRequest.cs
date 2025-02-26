using BankingCreditSystem.Domain.Enums;

public class CreateCreditTypeRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public CustomerType CustomerType { get; set; }
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTerm { get; set; }
    public int MaxTerm { get; set; }
    public decimal BaseInterestRate { get; set; }
    public Guid? ParentCreditTypeId { get; set; }
} 