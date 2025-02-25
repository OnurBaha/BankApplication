using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class CreditTypeConfiguration : IEntityTypeConfiguration<CreditType>
{
    public void Configure(EntityTypeBuilder<CreditType> builder)
    {
        builder.ToTable("CreditTypes");
        
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.MinAmount).HasColumnType("decimal(18,2)");
        builder.Property(x => x.MaxAmount).HasColumnType("decimal(18,2)");
        builder.Property(x => x.BaseInterestRate).HasColumnType("decimal(5,2)");
        
        builder.HasOne(x => x.ParentCreditType)
               .WithMany(x => x.SubCreditTypes)
               .HasForeignKey(x => x.ParentCreditTypeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
} 