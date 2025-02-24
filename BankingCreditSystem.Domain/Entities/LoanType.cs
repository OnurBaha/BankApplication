using System;
using System.Collections.Generic;
using BankingCreditSystem.Domain.Enums;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Domain.Entities
{
    public class LoanType : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CustomerType CustomerType { get; set; } // Enum: Individual, Corporate
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int MinTerm { get; set; } // Ay cinsinden
        public int MaxTerm { get; set; }
        public decimal BaseInterestRate { get; set; }
        
        public Guid? ParentLoanTypeId { get; set; }
        public virtual LoanType? ParentLoanType { get; set; }
        public virtual ICollection<LoanType> SubTypes { get; set; }
        public virtual ICollection<LoanApplication> LoanApplications { get; set; }
    }
} 