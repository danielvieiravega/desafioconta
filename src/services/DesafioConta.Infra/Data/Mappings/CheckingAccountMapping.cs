using DesafioConta.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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

            builder.Property(e => e.Balance).HasColumnType("decimal");

            //builder.HasMany(c => c.OperationsHistory)
            //    .WithOne(c => c.CheckingAccount)
            //    .HasForeignKey(c => c.CheckingAccountId);

            builder.OwnsMany(p => p.OperationsHistory, a =>
            {
                //a.WithOwner().HasForeignKey("CheckingAccountId");

                a.ToTable("OperationsHistory");

                //builder.Property(e => e.DateTime).HasColumnType("datetime");

                a.Property(e => e.Amount).HasColumnType("decimal");

                a.Property(e => e.Operation).HasColumnType("int");
            });

            //conta -> cliente
            builder.HasOne(c => c.Customer)
                .WithOne(c => c.CheckingAccount);
        }
    }
}
