public class CreateCreditApplicationRequest
{
    public Guid CreditTypeId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; }
} 