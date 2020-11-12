using DesafioConta.Domain.Data;
using System;
using System.Threading.Tasks;

namespace DesafioConta.Domain.Accounts
{
    public interface ICheckingAccountRepository : IRepository<Account>
    {
        Task<CheckingAccount> GetById(Guid id);
        Task<CheckingAccount> GetByCpf(Cpf cpf);

    }
}
