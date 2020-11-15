namespace DesafioConta.Domain.Accounts
{
    public interface IBoletoHelper
    {
        bool Validate(string code);
        decimal GetChargeAmount(string code);
    }
}
