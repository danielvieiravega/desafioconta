namespace DesafioConta.Domain.Account
{
    public class CheckingAccount : Account
    {
        public CheckingAccount()
        {
            Balance = 0;
        }

        public override void Deposit(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public override void WithDraw()
        {
            throw new System.NotImplementedException();
        }
    }
}
