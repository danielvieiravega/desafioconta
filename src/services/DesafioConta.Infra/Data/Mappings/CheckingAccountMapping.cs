using DesafioConta.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioConta.Infra.Data.Mappings
{
    public class CheckingAccountMapping : IEntityTypeConfiguration<CheckingAccount>
    {
        public void Configure(EntityTypeBuilder<CheckingAccount> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("CheckingAccounts");

            builder.Property(c => c.Agency)
               .IsRequired()
               .HasColumnName("Agency");

            builder.Property(c => c.Number)
               .IsRequired()
               .HasColumnName("Number");

            builder.Property(e => e.Balance)
               .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(16, 3);

            builder.Property(e => e.Yield)
               .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(16, 3);

            builder.OwnsMany(p => p.OperationsHistory, a =>
            {
                a.ToTable("OperationsHistory");

                a.Property(e => e.Amount)
                .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(16, 3);

                a.Property(e => e.Operation)
                .IsRequired()
                .HasColumnType("int");
            });

            builder.HasOne(c => c.Customer)
                .WithOne(c => c.CheckingAccount);
        }
    }
}
