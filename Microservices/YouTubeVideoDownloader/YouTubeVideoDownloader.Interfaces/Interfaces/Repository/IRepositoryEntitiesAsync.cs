using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Interfaces.Repository.Base;

namespace YouTubeVideoDownloader.Interfaces.Interfaces.Repository
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
        Task<bool> AddEntityAsync(T entity, CancellationToken cancel = default);

        /// <summary>
        /// Асинхронно обновить сущность <see cref="T"/>
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        /// <returns>True - сущность успешно обновлена, False - сущность не обновлена</returns>
        Task<bool> UpdateEntity(T entity, CancellationToken cancel = default);

        /// <summary>
        /// Асинхронно удалить сущность
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <returns>True - сущность удалена, False - сущность не удалена</returns>
        Task<bool> DeleteEntityById(Guid id, CancellationToken cancel = default);

        /// <summary>
        /// Асинхронно сохранить изменения в базу
        /// </summary>
        /// <returns>True - изменения сохранены, Fales - изменения не сохранены</returns>
        Task<bool> SaveChangesAsync();
    }
}
