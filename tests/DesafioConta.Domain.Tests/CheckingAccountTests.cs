using DesafioConta.Domain.Accounts;
using System;
using Xunit;

namespace DesafioConta.Tests
{
    public class CheckingAccountTests
    {
        [Fact]
        public void CreateValidUser()
        {
            var number = 1;
            var name = new Name("Daniel", "Vega");
            var cpf = new Cpf("03480365078");
            var address = new Address("Warren Street", "123", "Casa", "Money", "94064340", "Porto Alegre", "RS");


            var holder = new Customer(name, cpf, address, Guid.NewGuid());

            var newAccount = new CheckingAccount(number);
        }
    }
}
