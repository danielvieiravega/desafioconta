using System.Threading.Tasks;

namespace DesafioConta.Domain.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        bool Commit();
    }
}
