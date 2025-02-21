using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id");
        builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
        builder.Property(c => c.Email).HasColumnName("Email").IsRequired();
        builder.Property(c => c.Address).HasColumnName("Address").IsRequired();
        builder.Property(c => c.IsActive).HasColumnName("IsActive");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.UseTptMappingStrategy();
    }
} 