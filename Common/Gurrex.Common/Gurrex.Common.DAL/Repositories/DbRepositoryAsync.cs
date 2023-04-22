using Gurrex.Common.DAL.Entities;
using Gurrex.Common.DAL.Repositories.Base;
using Gurrex.Common.Interfaces.Repositories;
using Gurrex.Common.Validations;
using Microsoft.EntityFrameworkCore;

namespace Gurrex.Common.DAL.Repositories
{
    /// <summary>
    /// Базовый асинхронный репозиторий работы с сущностью, унаследованной от <see cref="Entity"/>
    /// </summary>
    /// <typeparam name="T">Сущность, унаследованная от <see cref="Entity"/></typeparam>
    public class DbRepositoryAsync<T> : BaseDbRepository<T>, IRepositoryEntitiesAsync<T> where T : Entity, new()
    {

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="dbContext">Контекст базы данных</param>
        protected DbRepositoryAsync(DbContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// Асинхронно получить экземпляр по Id
        /// </summary>
        /// <param name="id">Id экземпляра</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>Полученный экземпляр</returns>
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

        /// <summary>
        /// Асинхронно получить последний добавленный экземпляр сущности
        /// </summary>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>Полученный экземпляр</returns>
        public async Task<T> GetLastEntityAsync(CancellationToken cancel = default)
        {
            try
            {
                IEnumerable<T> entityList = await Items.ToListAsync().ConfigureAwait(false);
                return entityList.Last();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Асинхронно добавить экземпляр сущности
        /// </summary>
        /// <param name="entity">Добавляемый экземпляр сущности</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>True - экземпляр добавился, False - экземпляр не добавился</returns>
        public async Task<bool> AddEntityAsync(T entity, CancellationToken cancel = default)
        {
            try
            {
                entity.CheckObjectForNull(nameof(entity));
                _dbContext.Entry(entity).State = EntityState.Added;

                if (autoSaveChanges)
                {
                    await SaveChangesAsync(cancel);
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Асинхронно обновить экземпляр сущности
        /// </summary>
        /// <param name="entity">Обновляемый экземпляр сущности</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>True - экземпляр обновился, False - экземпляр не обновился</returns>
        public async Task<bool> UpdateEntityAsync(T entity, CancellationToken cancel = default)
        {
            try
            {
                entity.CheckObjectForNull(nameof(entity));
                _dbContext.Entry(entity).State = EntityState.Modified;

                if (autoSaveChanges)
                {
                    await SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Асинхронно удалить экземпляр сущности
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>True - экземпляр удален, False - укземпляр не удален</returns>
        public async Task<bool> RemoveEntityByIdAsync(Guid id, CancellationToken cancel = default)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Асинхронно сохранить изменения в базе данных
        /// </summary>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>True - изменения сохранились, False - изменения не сохранились</returns>
        public async Task<bool> SaveChangesAsync(CancellationToken cancel = default)
        {
            try
            {
                await _dbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
