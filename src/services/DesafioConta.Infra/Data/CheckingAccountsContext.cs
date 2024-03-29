﻿using DesafioConta.Domain.Accounts;
using DesafioConta.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioConta.Infra.Data
{
    public class CheckingAccountsContext : DbContext, IUnitOfWork
    {
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OperationsHistory> OperationsHistory { get; set; }

        public CheckingAccountsContext(DbContextOptions<CheckingAccountsContext> options)
           : base(options)
        {
        }

        public async Task<bool> CommitAsync()
        {

            return await base.SaveChangesAsync() > 0;

        }
        public bool Commit()
        {
            return base.SaveChanges() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CheckingAccountsContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
