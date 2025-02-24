using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankingCreditSystem.Domain.Enums;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Domain.Entities
{
    public class LoanApplication : Entity<Guid>
    {
        public Guid LoanTypeId { get; set; }
        public virtual LoanType LoanType { get; set; }
        
        public Guid? IndividualCustomerId { get; set; }
        public virtual IndividualCustomer? IndividualCustomer { get; set; }
        
        public Guid? CorporateCustomerId { get; set; }
        public virtual CorporateCustomer? CorporateCustomer { get; set; }
        
        public decimal RequestedAmount { get; set; }
        public int RequestedTerm { get; set; }
        public decimal MonthlyIncome { get; set; }
        public DateTime ApplicationDate { get; set; }
        public LoanApplicationStatus Status { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public decimal? ApprovedInterestRate { get; set; }
        public string? RejectionReason { get; set; }
    }
} 