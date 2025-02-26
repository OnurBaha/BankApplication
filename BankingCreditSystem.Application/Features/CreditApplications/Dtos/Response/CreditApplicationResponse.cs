public class CreditApplicationResponse
{
    public Guid Id { get; set; }
    public Guid CreditTypeId { get; set; }
    public string CreditTypeName { get; set; } = default!;
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = default!;
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; }
    public decimal ApprovedAmount { get; set; }
    public int ApprovedTerm { get; set; }
    public decimal InterestRate { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal TotalPayment { get; set; }
    public CreditApplicationStatus Status { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime CreatedDate { get; set; }
} 