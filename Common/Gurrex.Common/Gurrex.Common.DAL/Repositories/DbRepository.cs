using Gurrex.Common.DAL.Entities;
using Gurrex.Common.DAL.Repositories.Base;
using Gurrex.Common.Interfaces.Repositories;
using Gurrex.Common.Validations;
using Microsoft.EntityFrameworkCore;

namespace Gurrex.Common.DAL.Repositories
{
    /// <summary>
    /// Базовый репозиторий работы с сущностью, унаследованной от <see cref="Entity"/>
    /// </summary>
    /// <typeparam name="T">Сущность, унаследованная от <see cref="Entity"/></typeparam>
    public class DbRepository<T> : BaseDbRepository<T>, IRepositoryEntities<T> where T : Entity, new()
    {
        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="dbContext">Контекст базы данных</param>
        public DbRepository(DbContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// Получить экземпляра сущности по Id
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <returns>Полученная сущность</returns>
        public T GetEntityById(Guid id)
        {
            try
            {
                T? entity = Items.SingleOrDefault(item => item.Id == id);
                entity.CheckObjectForNull(nameof(entity));
                return entity!;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        /// <summary>
        /// Получить последнюю добавленную сущность
        /// </summary>
        /// <returns>Полученная сущность</returns>
        public T GetLastEntity()
        {
            try
            {
                IEnumerable<T> entityList = Items.ToList();
                return entityList.Last();
            }
            catch (Exception) 
            {
                throw;
            }
        }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        /// <returns>True - сущность добавлена, False - сущность не добавлена</returns>
        public bool AddEntity(T entity)
        {
            try
            {
                entity.CheckObjectForNull(nameof(entity));
                _dbContext.Entry(entity).State = EntityState.Added;

                if (autoSaveChanges)
                {
                    SaveChanges();
                }

                return true;
            }
            catch (Exception) 
            {
                throw;
            }

        }

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        /// <returns>True - сущность обновлена, False - сущность не не обновлена</returns>
        public bool UpdateEntity(T entity)
        {
            try
            {
                entity.CheckObjectForNull(nameof(entity));
                _dbContext.Entry(entity).State = EntityState.Modified;

                if (autoSaveChanges)
                {
                    SaveChanges();
                }

                return true;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <returns>True - сущность удалена, False - сущность не удалена</returns>
        public bool RemoveEntityById(Guid id)
        {
            try
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
            catch (Exception) 
            {
                throw;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception) 
            {
                throw;
            }
        }
    }
}
