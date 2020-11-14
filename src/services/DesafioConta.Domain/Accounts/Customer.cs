using DesafioConta.Core.DomainObjects;
using System;

namespace DesafioConta.Domain.Accounts
{
    public class Customer : SoftDeleteEntity
    {
        public Name Name { get; private set; }
        public Cpf Cpf { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
        public CheckingAccount CheckingAccount { get; private set; }
        public Guid CheckingAccountId { get; private set; }

        protected Customer()
        {

        }

        public Customer(Name name, Cpf cpf, Address address, Guid checkingAccountId)
        {
            Name = name;
            Cpf = cpf;
            Address = address;
            CheckingAccountId = checkingAccountId;
        }
    }
}
