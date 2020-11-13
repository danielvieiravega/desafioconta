﻿using DesafioConta.Domain.Accounts;
using DesafioConta.Domain.Data;
using Microsoft.EntityFrameworkCore;
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

        public void Add(CheckingAccount account)
        {
            _context.CheckingAccounts.Add(account);
        }

        public async Task<CheckingAccount> GetByCpf(Cpf cpf)
        {
            return await _context.CheckingAccounts.FirstAsync(a => a.Holder.Cpf == cpf);
        }

        public async Task<CheckingAccount> GetById(Guid id)
        {
            return await _context.CheckingAccounts.FirstAsync(a => a.Id == id);
        }

        public void Update(CheckingAccount account)
        {
            _context.CheckingAccounts.Update(account);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}