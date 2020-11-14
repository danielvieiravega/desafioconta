using DesafioConta.Domain.Accounts;
using DesafioConta.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioConta.Infra.Data
{

    public class CustomerRepository : ICustomerRepository
    {

        private readonly CheckingAccountsContext _context;

        public CustomerRepository(CheckingAccountsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }
    }

    public class CheckingAccountRepository : ICheckingAccountRepository
    {
        private readonly CheckingAccountsContext _context;

        public CheckingAccountRepository(CheckingAccountsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(CheckingAccount account)
        {
            _context.CheckingAccounts.Add(account);
        }

        public async Task<CheckingAccount> GetByCpf(Cpf cpf)
        {
            return await _context.CheckingAccounts.FirstAsync(a => a.Customer.Cpf.Number == cpf.Number);
        }

        public async Task<CheckingAccount> GetById(Guid id)
        {
            return await _context
                .CheckingAccounts
                .Include(c => c.Customer)
                .Include(h => h.OperationsHistory)
                .FirstAsync(a => a.Id == id);
        }

        public void Update(CheckingAccount account)
        {
            _context.CheckingAccounts.Update(account);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<CheckingAccount>> GetAll()
        {
            return await _context.CheckingAccounts.ToListAsync();
        }
    }
}
