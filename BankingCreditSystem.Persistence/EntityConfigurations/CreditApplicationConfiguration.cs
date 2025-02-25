using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class CreditApplicationConfiguration : IEntityTypeConfiguration<CreditApplication>
{
    public void Configure(EntityTypeBuilder<CreditApplication> builder)
    {
        builder.ToTable("CreditApplications");
        
        builder.Property(x => x.RequestedAmount).HasColumnType("decimal(18,2)");
        builder.Property(x => x.ApprovedAmount).HasColumnType("decimal(18,2)");
        builder.Property(x => x.InterestRate).HasColumnType("decimal(5,2)");
        builder.Property(x => x.MonthlyPayment).HasColumnType("decimal(18,2)");
        builder.Property(x => x.TotalPayment).HasColumnType("decimal(18,2)");
        
        builder.HasOne(x => x.CreditType)
               .WithMany(x => x.CreditApplications)
               .HasForeignKey(x => x.CreditTypeId);
               
        builder.HasOne(x => x.Customer)
               .WithMany()
               .HasForeignKey(x => x.CustomerId);
    }
} 