using Gurrex.Common.DAL.Entities;
using Gurrex.Common.Helpers;
using Gurrex.Common.Interfaces;
using Gurrex.Common.Interfaces.Repositories.Base;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Gurrex.Common.DAL.Repositories.Base
{
    /// <summary>
    /// Базовый класс работы с сущностью, унаследованной от <see cref="Entity"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDbRepository<T> : IRepository<T>, IResources where T : Entity, new()
    {

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public virtual string ResourcesPath => $"{Assembly}.Repositories.Base.BaseDbRepository";

        /// <summary>
        /// Сборка
        /// </summary>
        public Assembly Assembly => StaticHelpers.GetAssemblyInfo().Assembly;

        /// <summary>
        /// Имя сборки
        /// </summary>
        public AssemblyName AssemblyName => StaticHelpers.GetAssemblyInfo().AssemblyName;

        /// <summary>
        /// Логирование
        /// </summary>
        private readonly ILogger<BaseDbRepository<T>> _logger;

        /// <summary>
        /// Контекст базы данных
        /// </summary>
        protected readonly DbContext _dbContext;

        /// <summary>
        /// DbSet сущности, унаследованной от <see cref="Entity"/>
        /// </summary>
        protected readonly DbSet<T> _entities;

        /// <summary>
        /// Автоматическое сохранение изменений
        /// </summary>
        protected bool autoSaveChanges = true;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="dbContext">Контекст базы данных</param>
        /// <param name="logger">Логирование</param>
        protected BaseDbRepository(DbContext dbContext, ILogger<BaseDbRepository<T>> logger)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
            _logger = logger;
            string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "DebugInitializationBaseRepository", Assembly));
            _logger.LogDebug(ManagerResources.GetResultString(localizationString));
        }

        /// <summary>
        /// Количество экземпляров сущности, унаследованной от <see cref="Entity"/>
        /// </summary>
        public IQueryable<T> Items => _entities;
    }
}
