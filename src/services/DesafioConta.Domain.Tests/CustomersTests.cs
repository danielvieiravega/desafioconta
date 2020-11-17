using DesafioConta.Domain.Accounts;
using System;
using Xunit;

namespace DesafioConta.Tests
{
    public class CustomersTests
    {
        [Fact]
        public void Customer_NewCustomer_ShouldBeValid()
        {
            var name = new Name("Daniel", "Vega");
            var cpf = new Cpf("03480365078");
            var address = new Address("Warren Street", "123", "Casa", "Money", "94064340", "Porto Alegre", "RS");

            var customer = new Customer(name, cpf, address, Guid.NewGuid());
            Assert.NotNull(customer);
            Assert.Equal(name.FirstName, customer.Name.FirstName);
            Assert.Equal(cpf.Number, customer.Cpf.Number);
        }
    }
}
