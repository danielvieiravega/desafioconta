using DesafioConta.Domain.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioConta.Domain.Accounts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Customer>> GetAll();
    }
}
