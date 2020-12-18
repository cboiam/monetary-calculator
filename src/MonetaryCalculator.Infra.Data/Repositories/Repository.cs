using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MonetaryCalculator.Infra.Data.Repositories
{
    public sealed class Repository<T> : IRepository<T>
        where T : class
    {
        public DbSet<T> DbSet { get; }
        private readonly EmployeeContext context;

        public Repository(EmployeeContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            var result = await DbSet.AddAsync(entity);
            await Save();

            return result.Entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await Get(id);
            DbSet.Remove(entity);
            await Save();

            return entity;
        }

        public async Task<T> Get(int id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<T> Update(T entity)
        {
            var result = DbSet.Update(entity);
            await Save();

            return result.Entity;
        }

        private async Task<bool> Save()
        {
            int linesChanged = await context.SaveChangesAsync();
            return linesChanged != default;
        }
    }
}
