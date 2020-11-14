using DesafioConta.Core.DomainObjects;

namespace DesafioConta.Domain.Accounts
{
    public class Address : ValueObject
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        
        public Address(
            string logradouro, 
            string numero, 
            string complemento, 
            string bairro, 
            string cep, 
            string cidade, 
            string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
