namespace DesafioConta.Domain.Accounts
{
    public interface IBoletoHelper
    {
        decimal GetChargeAmount(string code);
    }
}
