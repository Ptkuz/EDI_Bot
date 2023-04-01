using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeVideoDownloader.Interfaces.Interfaces.Repository.Base;

namespace YouTubeVideoDownloader.Interfaces.Interfaces.Repository
{
    /// <summary>
    /// Синхронный репозиторий сущностей
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    public interface IRepositoryEntitiesSync<T> : IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Получить конкретную сущность <see cref="T"/> по Id
        /// </summary>
        /// <param name="id">Id сущности с типом <see cref="Guid"/></param>
        /// <returns>Возвращает конкретную сущность <see cref="T"/> по Id</returns>
        T? GetEntityById(Guid id);

        /// <summary>
        /// Получить последнюю добавленную сущность <see cref="T"/>
        /// </summary>
        /// <returns>Возвращает последнюю добавленную сущность <see cref="T"/></returns>
        T GetLastEntity();

        /// <summary>
        /// Добавить сущность <see cref="T"/>
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        /// <returns>True - сущность успешно добавлена, False - сущность не добавлена</returns>
        bool AddEntity(T entity);

        /// <summary>
        /// Обновить сущность <see cref="T"/>
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        /// <returns>True - сущность успешно обновлена, False - сущность не обновлена</returns>
        bool UpdateEntity(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <returns>True - сущность удалена, False - сущность не удалена</returns>
        bool DeleteEntityById(Guid id);

        /// <summary>
        /// Сохранить изменения в базу
        /// </summary>
        /// <returns>True - изменения сохранены, Fales - изменения не сохранены</returns>
        bool SaveChanges();
    }
}
