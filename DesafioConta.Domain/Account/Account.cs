using DesafioConta.Domain.DomainObjects;

namespace DesafioConta.Domain.Account
{
    public abstract class Account : SoftDeleteEntity, IAggregateRoot
    {
        public decimal Balance { get; protected set; }

        public abstract void Deposit(decimal amount);


        public abstract void WithDraw();


    }
}
