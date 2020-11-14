using DesafioConta.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using System;

namespace DesafioConta.Infra.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var customerId = Guid.NewGuid();
            var checkingAccountId = Guid.NewGuid();

            modelBuilder.Entity<CheckingAccount>().HasData(
                new
                {
                    Id = checkingAccountId,
                    Balance = (decimal)500,
                    Agency = 1,
                    Number = 1,
                    CreationDate = DateTime.Now.AddDays(-15),
                    LastMonetization = DateTime.Now.AddDays(-15)
                }
                );


            modelBuilder.Entity<OperationsHistory>().HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    CheckingAccountId = checkingAccountId,
                    Operation = Operation.Deposit,
                    Amount = (decimal) 100.0,
                    CreationDate = DateTime.Now.AddDays(-7)
                },
                new
                {
                    Id = Guid.NewGuid(),
                    CheckingAccountId = checkingAccountId,
                    Operation = Operation.Deposit,
                    Amount = (decimal) 400.0,
                    CreationDate = DateTime.Now.AddDays(-5)
                }
                );


            modelBuilder.Entity<Customer>(c =>
            {
                c.HasData(new { Id = customerId, CheckingAccountId = checkingAccountId, CreationDate = DateTime.Now });

                c.OwnsOne(e => e.Address).HasData(
                    new
                    {
                        CustomerId = customerId,
                        Logradouro = "Warren Street",
                        Numero = "123",
                        Complemento = "Casa",
                        Bairro = "Money",
                        Cep = "94064340",
                        Cidade = "Porto Alegre",
                        Estado = "RS"

                    });

                c.OwnsOne(e => e.Cpf).HasData(
                    new
                    {
                        CustomerId = customerId,
                        Number = "34074230046"
                    });

                c.OwnsOne(e => e.Email).HasData(
                    new
                    {
                        CustomerId = customerId,
                        Address = "warren@buffet.com"
                    });

                c.OwnsOne(e => e.Name).HasData(
                    new
                    {
                        CustomerId = customerId,
                        FirstName = "Warren",
                        LastName = "Buffet"
                    });
            });
        }
    }
}
