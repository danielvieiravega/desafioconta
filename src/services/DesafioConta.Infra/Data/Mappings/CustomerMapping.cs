using DesafioConta.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioConta.Infra.Data.Mappings
{
    class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(p => p.Name, e =>
            {
                e.Property(pe => pe.FirstName)
                   .HasColumnName("FirstName");

                e.Property(pe => pe.LastName)
                   .HasColumnName("LastName");
            });

            builder.OwnsOne(p => p.Cpf, e =>
            {
                e.Property(pe => pe.Number)
                   .IsRequired()
                    .HasMaxLength(Cpf.CpfMaxLength)
                    .HasColumnName("Cpf")
                    .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            });

            builder.OwnsOne(p => p.Email, e =>
            {
                e.Property(pe => pe.Address)
                   .HasColumnName("Email")
                   .HasColumnType($"varchar({Email.AddressoMaxLength})");
            });

            builder.OwnsOne(p => p.Address, e =>
            {
                e.Property(pe => pe.Logradouro)
                    .HasColumnName("Logradouro")
                    .HasColumnType("varchar(200)");

                e.Property(pe => pe.Numero)
                   .HasColumnName("Numero")
                   .HasColumnType("varchar(50)");

                e.Property(pe => pe.Complemento)
                    .HasColumnName("Complemento")
                    .HasColumnType("varchar(250)");

                e.Property(pe => pe.Bairro)
                    .HasColumnName("Bairro")
                    .HasColumnType("varchar(100)");

                e.Property(pe => pe.Cep)
                    .HasColumnName("Cep")
                    .HasColumnType("varchar(20)");

                e.Property(pe => pe.Cidade)
                    .HasColumnName("Cidade")
                    .HasColumnType("varchar(100)");

                e.Property(pe => pe.Estado)
                    .HasColumnName("Estado")
                    .HasColumnType("varchar(50)");
            });

            builder.ToTable("Customers");
        }
    }
}
