using DesafioConta.Domain.DomainObjects;
using System;

namespace DesafioConta.Domain.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
