using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessObjects.Configurations.SystemAccountConfiguration;

public class SystemAccountConfiguration : IEntityTypeConfiguration<SystemAccount>
{
    public void Configure(EntityTypeBuilder<SystemAccount> builder)
    {
        builder.HasKey(sa => sa.Id);

        builder.Property(sa => sa.AccountName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(sa => sa.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(sa => sa.AccountRole)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(sa => sa.AccountPassword)
            .IsRequired()
            .HasMaxLength(100);

    }
}