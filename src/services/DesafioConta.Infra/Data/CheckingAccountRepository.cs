using DesafioConta.Domain.Accounts;
using DesafioConta.Domain.Data;
using System;
using System.Threading.Tasks;

namespace DesafioConta.Infra.Data
{
    public class CheckingAccountRepository : ICheckingAccountRepository
    {
        private readonly CheckingAccountsContext _context;

        public CheckingAccountRepository(CheckingAccountsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<CheckingAccount> GetByCpf(Cpf cpf)
        {
            throw new NotImplementedException();
        }

        public Task<CheckingAccount> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
