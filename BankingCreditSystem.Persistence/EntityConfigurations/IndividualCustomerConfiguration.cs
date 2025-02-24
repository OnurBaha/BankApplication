using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.ToTable("IndividualCustomers");

        builder.Property(c => c.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(c => c.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(c => c.NationalId).HasColumnName("NationalId").IsRequired();
        builder.Property(c => c.DateOfBirth).HasColumnName("DateOfBirth").IsRequired();
        builder.Property(c => c.MotherName).HasColumnName("MotherName");
        builder.Property(c => c.FatherName).HasColumnName("FatherName");
    }
} 