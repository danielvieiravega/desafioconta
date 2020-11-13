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

            builder.OwnsOne(p => p.Holder, e =>
            {
                e.Property(pe => pe.Name.FirstName)
                   .HasColumnName("FirstName");

                e.Property(pe => pe.Name.LastName)
                   .HasColumnName("LastName");

                e.Property(pe => pe.Cpf.Number)
                   .HasColumnName("Cpf");

                e.Property(pe => pe.Email.Address)
                  .HasColumnName("Email");

                e.Property(pe => pe.Address.Logradouro)
                    .HasColumnName("Logradouro");

                e.Property(pe => pe.Address.Numero)
                   .HasColumnName("Numero");

                e.Property(pe => pe.Address.Complemento)
                    .HasColumnName("Complemento");

                e.Property(pe => pe.Address.Bairro)
                    .HasColumnName("Bairro");

                e.Property(pe => pe.Address.Cep)
                    .HasColumnName("Cep");

                e.Property(pe => pe.Address.Cidade)
                    .HasColumnName("Cidade");

                e.Property(pe => pe.Address.Estado)
                    .HasColumnName("Estado");
            });

            builder.Property(c => c.Agency)
               .IsRequired()
               .HasColumnName("Agency");

            builder.Property(c => c.Number)
               .IsRequired()
               .HasColumnName("Number");

            builder.Property(e => e.Balance).HasColumnType("Money");

            builder.HasMany(c => c.OperationsHistory)
                .WithOne(c => c.CheckingAccount)
                .HasForeignKey(c => c.CheckingAccountId);
        }
    }
}
