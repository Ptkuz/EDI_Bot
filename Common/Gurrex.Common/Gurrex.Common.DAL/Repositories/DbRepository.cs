using Gurrex.Common.DAL.Entities;
using Gurrex.Common.Interfaces.Repositories;
using Gurrex.Common.Validations;
using Microsoft.EntityFrameworkCore;

namespace Gurrex.Common.DAL.Repositories
{
    public class DbRepository<T> : IRepositoryEntities<T> where T : Entity, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _entities;

        private bool autoSaveChanges = true;

        public DbRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }


        public IQueryable<T> Items => _entities;

        public T GetEntityById(Guid id)
        {
            T? entity = Items.SingleOrDefault(item => item.Id == id);
            entity.CheckObjectForNull(nameof(entity));
            return entity!;
        }

        public T GetLastEntity()
        {
            IEnumerable<T> entityList = Items.ToList();
            return entityList.Last();
        }

        public T AddEntity(T entity)
        {
            entity.CheckObjectForNull(nameof(entity));
            _dbContext.Entry(entity).State = EntityState.Added;
            if (autoSaveChanges)
            {
                SaveChanges();
            }
            return entity;

        }

        public T UpdateEntity(T entity)
        {
            entity.CheckObjectForNull(nameof(entity));
            _dbContext.Entry(entity).State = EntityState.Modified;

            if (autoSaveChanges)
            {
                SaveChanges();
            }
            return entity;
        }

        public bool RemoveEntityById(Guid id)
        {
            T entity = new T { Id = id };
            _dbContext.Remove(entity);

            if (autoSaveChanges)
            {
                SaveChanges();
                return true;
            }
            return false;
        }

        public bool SaveChanges()
        {
            _dbContext.SaveChanges();
            return true;
        }
    }
}
