using DesafioConta.Core.DomainObjects;

namespace DesafioConta.Domain.Accounts
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            //TODO: Fazer a validaçaõ de email!!!!!
            Address = address;
        }
    }
}
