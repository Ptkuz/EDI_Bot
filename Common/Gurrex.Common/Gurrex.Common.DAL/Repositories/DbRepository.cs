using Gurrex.Common.DAL.Entities;
using Gurrex.Common.DAL.Repositories.Base;
using Gurrex.Common.Interfaces.Repositories;
using Gurrex.Common.Localization.Models;
using Gurrex.Common.Localization;
using Gurrex.Common.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Gurrex.Common.Interfaces;

namespace Gurrex.Common.DAL.Repositories
{
    /// <summary>
    /// Базовый репозиторий работы с сущностью, унаследованной от <see cref="Entity"/>
    /// </summary>
    /// <typeparam name="T">Сущность, унаследованная от <see cref="Entity"/></typeparam>
    public class DbRepository<T> : BaseDbRepository<T>, IRepositoryEntities<T> where T : Entity, new()
    {
        /// <summary>
        /// Логирование
        /// </summary>
        private readonly ILogger<DbRepository<T>> _logger;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public override string ResourcesPath => $"{AssemblyInfo.AssemblyName.Name}.Resources.Repositories.DbRepository";

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="dbContext">Контекст базы данных</param>
        /// <param name="logger">Контекст базы данных</param>
        protected DbRepository(DbContext dbContext, ILogger<DbRepository<T>> logger) 
            : base(dbContext, logger)
        {
            _logger = logger;
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
