using DesafioConta.Core.DomainObjects;

namespace DesafioConta.Domain.Accounts
{
    public class Holder : ValueObject
    {
        public Name Name { get; private set; }
        public Cpf Cpf { get; private set; }
        public Address Address { get; private set; }

        public Email Email { get; private set; }

        public Holder(Name name, Cpf cpf, Address address)
        {
            Name = name;
            Cpf = cpf;
            Address = address;
        }
    }
}
