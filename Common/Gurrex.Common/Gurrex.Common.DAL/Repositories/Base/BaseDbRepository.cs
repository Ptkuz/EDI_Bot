﻿using Gurrex.Common.DAL.Entities;
using Gurrex.Common.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Gurrex.Common.DAL.Repositories.Base
{
    /// <summary>
    /// Базовый класс работы с сущностью, унаследованной от <see cref="Entity"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDbRepository<T> : IRepository<T> where T : Entity, new()
    {
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
        protected BaseDbRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }

        /// <summary>
        /// Количество экземпляров сущности, унаследованной от <see cref="Entity"/>
        /// </summary>
        public IQueryable<T> Items => _entities;
    }
}
