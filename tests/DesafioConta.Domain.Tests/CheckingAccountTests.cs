using DesafioConta.Domain.Accounts;
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
            var address = new Address();

            var holder = new Holder(name, cpf, address);

            var newAccount = new CheckingAccount(number, holder);
        }
    }
}
