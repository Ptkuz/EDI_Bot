using Gurrex.Common.Interfaces.Entities;
using Gurrex.Common.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Interfaces.Repositories
{
    /// <summary>
    /// Асинхронный репозиторий сущностей
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    public interface IRepositoryEntitiesAsync<T> : IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Асинхронно получить конкретную сущность <see cref="T"/> по Id
        /// </summary>
        /// <param name="id">Id сущности с типом <see cref="Guid"/></param>
        /// <returns>Возвращает конкретную сущность <see cref="T"/> по Id</returns>
        Task<T> GetEntityByIdAsync(Guid id, CancellationToken cancel = default);

        /// <summary>
        /// Асинхронно получить последнюю добавленную сущность <see cref="T"/>
        /// </summary>
        /// <returns>Возвращает последнюю добавленную сущность <see cref="T"/></returns>
        Task<T> GetLastEntityAsync(CancellationToken cancel = default);

        /// <summary>
        /// Асинхронно добавить сущность <see cref="T"/>
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        /// <returns>True - сущность успешно добавлена, False - сущность не добавлена</returns>
        Task<T> AddEntityAsync(T entity, CancellationToken cancel = default);

        /// <summary>
        /// Асинхронно обновить сущность <see cref="T"/>
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        /// <returns>True - сущность успешно обновлена, False - сущность не обновлена</returns>
        Task<T> UpdateEntityAsync(T entity, CancellationToken cancel = default);

        /// <summary>
        /// Удаление сущности по Id
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns></returns>
        Task<bool> RemoveEntityByIdAsync(Guid id, CancellationToken cancel = default);

        /// <summary>
        /// Асинхронно сохранить изменения в базу
        /// </summary>
        /// <returns>True - изменения сохранены, Fales - изменения не сохранены</returns>
        Task<bool> SaveChangesAsync(CancellationToken cancel = default);
    }
}
