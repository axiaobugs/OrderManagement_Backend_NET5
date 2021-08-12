using System;
using System.Threading.Tasks;
using orderManagement.Core.Entities.Employees;
using orderManagement.Entities;

namespace orderManagement.Core.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();

    }
}