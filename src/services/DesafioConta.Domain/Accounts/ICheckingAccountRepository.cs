using DesafioConta.Domain.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioConta.Domain.Accounts
{
    public interface ICheckingAccountRepository : IRepository<CheckingAccount>
    {
        Task<List<CheckingAccount>> GetAll();
        Task<CheckingAccount> GetById(Guid id);
        Task<CheckingAccount> GetByCpf(Cpf cpf);
        void Add(CheckingAccount account);
        void Update(CheckingAccount account);
    }
}
