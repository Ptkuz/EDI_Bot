using Gurrex.Common.DAL.Entities;
using Gurrex.Common.Helpers;
using Gurrex.Common.Helpers.Models;
using Gurrex.Common.Interfaces.Repositories;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Gurrex.Common.DAL.Repositories
{
    /// <summary>
    /// Базовый асинхронный репозиторий работы с сущностью, унаследованной от <see cref="Entity"/>
    /// </summary>
    /// <typeparam name="T">Сущность, унаследованная от <see cref="Entity"/></typeparam>
    public class EntityRepository<T> : IEntityRepository<T> where T : Entity, new()
    {

        /// <summary>
        /// Сборка
        /// </summary>
        public AssemblyInfo AssemblyInfo => StaticHelpers.GetAssemblyInfo();

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public virtual string ResourcesPath => $"{AssemblyInfo.AssemblyName.Name}.Resources.Repositories.DbRepository";

        /// <summary>
        /// Логирование
        /// </summary>
        private readonly ILogger<EntityRepository<T>> _logger;

        /// <summary>
        /// Контекст базы данных
        /// </summary>
        protected readonly DbContext _dbContext;

        /// <summary>
        /// DbSet сущности, унаследованной от <see cref="Entity"/>
        /// </summary>
        protected DbSet<T> _entities;

        /// <summary>
        /// Автоматическое сохранение изменений
        /// </summary>
        private bool autoSaveChanges = true;

        private EntityRepository() 
        {
            
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="dbContext">Контекст базы данных</param>
        /// <param name="logger">Логирование</param>
        protected EntityRepository(DbContext dbContext, ILogger<EntityRepository<T>> logger)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
            _logger = logger;
        }

        /// <summary>
        /// Количество экземпляров сущности, унаследованной от <see cref="Entity"/>
        /// </summary>
        public IQueryable<T> Items => _entities;


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
        /// Найти коллекцию сущностей по делегату
        /// </summary>
        /// <param name="predicate">Делегат</param>
        /// <returns><see cref="IEnumerable{T}"/> сущностей</returns>
        public IEnumerable<T> FindEntity(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        /// <summary>
        /// Найти сущность по делегату
        /// </summary>
        /// <param name="predicate">Делегат</param>
        /// <returns><see cref="T"/></returns>
        public async Task<T?> SingleOrDefaultEntityAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.SingleOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Подключить связанную сущность
        /// </summary>
        /// <param name="predicate">Делегат</param>
        /// <returns><see cref="IEnumerable{T}"/> связанных сущностей</returns>
        public IQueryable<T> MultiInclude(params Expression<Func<T, object>>[] includes)
        {
            if (includes is not null)
            {
                return includes.Aggregate(Items, (current, include) => current.Include(include));
            }
            return Items;
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
            finally
            {
                _dbContext.Entry(entity).State = EntityState.Detached;
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
            finally
            {
                _dbContext.Entry(entity).State = EntityState.Detached;
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
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugGetEntityById", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));
                return entity!;
            }
            catch (Exception ex)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionGetEntityById", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), ex));
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
                T entity = entityList.Last();
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugGetLastEntity", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));
                return entity;
            }
            catch (Exception ex)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionGetLastEntity", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), ex));
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

                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugAddEntity", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));

                if (autoSaveChanges)
                {
                    SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionAddEntity", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), ex));
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

                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugUpdateEntity", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));

                if (autoSaveChanges)
                {
                    SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionUpdateEntity", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), ex));
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

                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugRemoveEntityById", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));

                if (autoSaveChanges)
                {
                    SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionRemoveEntityById", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), ex));
                throw;
            }
        }

        /// <summary>
        /// Сохранить изменения в базу данных
        /// </summary>
        /// <returns>True - изменения сохранены, False - изменения не сохранены</returns>
        public bool SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();

                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugSaveChanges", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T)));

                return true;
            }
            catch (Exception ex)
            {
                string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugExceptionSaveChanges", AssemblyInfo.Assembly));
                _logger.LogDebug(ManagerResources.GetResultString(localizationString, nameof(T), ex));
                throw;
            }
        }
    }
}
