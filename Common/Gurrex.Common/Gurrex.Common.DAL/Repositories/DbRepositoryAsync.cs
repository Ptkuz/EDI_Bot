using Gurrex.Common.DAL.Entities;
using Gurrex.Common.DAL.Repositories.Base;
using Gurrex.Common.Interfaces.Repositories;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gurrex.Common.DAL.Repositories
{
    /// <summary>
    /// Базовый асинхронный репозиторий работы с сущностью, унаследованной от <see cref="Entity"/>
    /// </summary>
    /// <typeparam name="T">Сущность, унаследованная от <see cref="Entity"/></typeparam>
    public class DbRepositoryAsync<T> : BaseDbRepository<T>, IRepositoryEntitiesAsync<T> where T : Entity, new()
    {

        private readonly ILogger _logger;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public override string ResourcesPath => $"{AssemblyInfo.AssemblyName.Name}.Repositories.DbRepositoryAsync";

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="dbContext">Контекст базы данных</param>
        /// <param name="logger">Контекст базы данных</param>
        protected DbRepositoryAsync(DbContext dbContext, ILogger<DbRepositoryAsync<T>> logger) : base(dbContext, logger)
        {
            _logger = logger;
            string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugInitializationDbRepositoryAsync", AssemblyInfo.Assembly));
            _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));
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

                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugGetEntityByIdAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), id));

                return entity!;
            }
            catch (Exception ex)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionGetEntityByIdAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), ex));
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
                T entity = entityList.Last();

                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugGetLastEntityAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));

                return entity;
            }
            catch (Exception)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionGetLastEntityAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));
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

                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugAddEntityAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));

                if (autoSaveChanges)
                {
                    await SaveChangesAsync(cancel);
                }

                return true;
            }
            catch (Exception ex)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionAddEntityAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), ex));
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

                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugUpdateEntityAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));

                if (autoSaveChanges)
                {
                    await SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionUpdateEntityAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), ex));
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

                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugRemoveEntityByIdAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), id));

                if (autoSaveChanges)
                {
                    await SaveChangesAsync(cancel);
                }

                return true;
            }
            catch (Exception ex)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionRemoveEntityByIdAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), ex));
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

                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugSaveChangesAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));

                return true;
            }
            catch (Exception ex)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionSaveChangesAsync", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), ex));
                throw;
            }
        }
    }
}
