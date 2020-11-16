using DesafioConta.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioConta.Infra.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var customerId = Guid.NewGuid();
            var checkingAccountId = Guid.Parse("A0ECF33E-4FFC-49F5-848C-B17E8377573E");

            modelBuilder.Entity<CheckingAccount>().HasData(
                new
                {
                    Id = checkingAccountId,
                    Balance = (decimal)0,
                    Yield = (decimal)0,
                    Agency = 1,
                    Number = 1,
                    CreationDate = DateTime.Now.AddDays(-15),
                    LastMonetization = DateTime.Now.AddDays(-15),
                    Deleted = false
                }
                );

            modelBuilder.Entity<Customer>(c =>
            {
                c.HasData(new { Id = customerId, CheckingAccountId = checkingAccountId, CreationDate = DateTime.Now, Deleted = false });

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
