using DesafioConta.Domain.Accounts;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DesafioConta.Infra.Boleto
{
    /// <summary>
    /// Validação bem simples, verificando somente se possui 47 digitos
    /// </summary>
    public class BoletoHelper : IBoletoHelper
    {
        public decimal GetChargeAmount(string code)
        {
            code = CleanCode(code);
            if (!IsValidCode(code))
                throw new System.Exception("Invalid Boleto code");

            var lastTenDigits = code.Substring(38);
            var beforeComma = lastTenDigits.Substring(0, 7);
            var afterComma = lastTenDigits.Substring(7);

            var decimalString = $"{beforeComma},{afterComma}";

            decimal result;
            if (decimal.TryParse(decimalString, NumberStyles.Float, new CultureInfo("pt-BR"), out result))
                return result;

            throw new System.Exception("Error on parsing boleto charge amount");
        }

        private static bool IsValidCode(string code)
        {
            var regexOnlyDigits = new Regex("^[0-9]*$");

            if (code.Length == 47 && regexOnlyDigits.IsMatch(code))
                return true;

            return false;
        }

        private static string CleanCode(string code)
        {
            code = code.Replace(".", "").Replace(" ", "").Trim();
            return code;
        }
    }
}
