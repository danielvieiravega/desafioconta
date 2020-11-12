using DesafioConta.Domain.Accounts;
using DesafioConta.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DesafioConta.Infra.Data
{
    public class CheckingAccountsContext : DbContext, IUnitOfWork
    {
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
        
    }
}
