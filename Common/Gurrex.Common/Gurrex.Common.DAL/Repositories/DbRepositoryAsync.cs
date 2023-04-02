using Gurrex.Common.DAL.Entities;
using Gurrex.Common.Interfaces.Repositories;
using Gurrex.Common.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.DAL.Repositories
{
    public class DbRepositoryAsync<T> : IRepositoryEntitiesAsync<T> where T : Entity, new()
    {

        private readonly DbContext _dbContext;
        private readonly DbSet<T> _entities;

        private bool autoSaveChanges = true;

        public DbRepositoryAsync(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }


        public IQueryable<T> Items => _entities;

        public async Task<T> GetEntityByIdAsync(Guid id, CancellationToken cancel = default)
        {
            try
            {
                T? entity = await Items.SingleOrDefaultAsync(item => item.Id == id).ConfigureAwait(false);
                entity.CheckObjectForNull(nameof(entity));
                return entity!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetLastEntityAsync(CancellationToken cancel = default)
        {
            IEnumerable<T> entityList = await Items.ToListAsync().ConfigureAwait(false);
            return entityList.Last();
        }

        public async Task<T> AddEntityAsync(T entity, CancellationToken cancel = default)
        {
            entity.CheckObjectForNull(nameof(entity));
            _dbContext.Entry(entity).State = EntityState.Added;
            if (autoSaveChanges)
            {
                await SaveChangesAsync(cancel);
            }
            return entity;

        }

        public async Task<T> UpdateEntityAsync(T entity, CancellationToken cancel = default)
        {
            entity.CheckObjectForNull(nameof(entity));
            _dbContext.Entry(entity).State = EntityState.Modified;

            if (autoSaveChanges)
            {
                await SaveChangesAsync();
            }
            return entity;
        }

        public async Task<bool> RemoveEntityByIdAsync(Guid id, CancellationToken cancel = default)
        {
            T entity = new T { Id = id };
            _dbContext.Remove(entity);

            if (autoSaveChanges)
            {
                await SaveChangesAsync(cancel);
                return true;
            }
            return false;
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancel = default)
        {
            await _dbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }
    }
}
