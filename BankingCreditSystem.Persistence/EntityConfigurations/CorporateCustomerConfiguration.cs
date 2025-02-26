using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.ToTable("CorporateCustomers");

        builder.Property(c => c.TaxNumber).HasColumnName("TaxNumber").IsRequired();
        builder.Property(c => c.CompanyName).HasColumnName("CompanyName").IsRequired();
        builder.Property(c => c.TaxOffice).HasColumnName("TaxOffice").IsRequired();
        builder.Property(c => c.CompanyRegistrationNumber).HasColumnName("CompanyRegistrationNumber").IsRequired();
        builder.Property(c => c.AuthorizedPersonName).HasColumnName("AuthorizedPersonName").IsRequired();
        builder.Property(c => c.CompanyFoundationDate).HasColumnName("CompanyFoundationDate").IsRequired();
    }
} 