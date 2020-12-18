using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MonetaryCalculator.Infra.Data
{
    public interface IRepository<T>
        where T : class
    {
        DbSet<T> DbSet { get; }
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
        Task<T> Get(int id, CancellationToken cancellationToken = default);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
