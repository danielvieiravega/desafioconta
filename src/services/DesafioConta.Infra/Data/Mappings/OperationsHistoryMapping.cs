using DesafioConta.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioConta.Infra.Data.Mappings
{
    public class OperationsHistoryMapping : IEntityTypeConfiguration<OperationsHistory>
    {
        public void Configure(EntityTypeBuilder<OperationsHistory> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("OperationsHistory");

            //builder.Property(e => e.DateTime).HasColumnType("datetime");

            builder.Property(e => e.Amount).HasColumnType("decimal");

            builder.Property(e => e.Operation).HasColumnType("int");

        }
    }
}
