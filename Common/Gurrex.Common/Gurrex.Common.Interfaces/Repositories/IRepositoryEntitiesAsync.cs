﻿using Gurrex.Common.Interfaces.Entities;
using Gurrex.Common.Interfaces.Repositories.Base;
using System.Linq.Expressions;

namespace Gurrex.Common.Interfaces.Repositories
{
    /// <summary>
    /// Асинхронный репозиторий работы с сущностью, реализующей интерфейс <see cref="IEntity"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IEntity"/></typeparam>
    public interface IRepositoryEntitiesAsync<T> : IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Асинхронно получить экземпляр сущности по Id
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>Экземпляр сущности</returns>
        Task<T> GetEntityByIdAsync(Guid id, CancellationToken cancel = default);

        /// <summary>
        /// Асинхронно получить последний добавленный экземпляр сущности
        /// </summary>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>Последний добавленный экземпляр</returns>
        Task<T> GetLastEntityAsync(CancellationToken cancel = default);

        IEnumerable<T> FindEntity(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Найти сущность по делегату
        /// </summary>
        /// <param name="predicate">Делегат</param>
        /// <returns><see cref="T"/></returns>
        Task<T?> SingleOrDefaultEntityAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Подключить связанную сущность
        /// </summary>
        /// <param name="predicate">Делегат</param>
        /// <returns><see cref="IQueryable{T}"/> связанных сущностей</returns>
        IQueryable<T> MultiInclude(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Асинхронно добавить экземпляр сущности
        /// </summary>
        /// <param name="entity">Добавляемый экземпляр</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>True - экземпляр добавлен, False - экземпляр не добавлен</returns>
        Task<bool> AddEntityAsync(T entity, CancellationToken cancel = default);

        /// <summary>
        /// Асинхронно обновить обновить экземпляр
        /// </summary>
        /// <param name="entity">Обновляемый экземпляр</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>True - экземпляр обновлен, False - экземпляр не обновлен</returns>
        Task<bool> UpdateEntityAsync(T entity, CancellationToken cancel = default);

        /// <summary>
        /// Асинхронно удалить экземпляр сущности
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns></returns>
        Task<bool> RemoveEntityByIdAsync(Guid id, CancellationToken cancel = default);

        /// <summary>
        /// Асинхронно сохранить изменения в базу
        /// </summary>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>True - изменения сохранены, False - изменения не сохранены</returns>
        Task<bool> SaveChangesAsync(CancellationToken cancel = default);
    }
}
