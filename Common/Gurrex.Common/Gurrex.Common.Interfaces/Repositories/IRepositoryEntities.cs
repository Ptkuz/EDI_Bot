using Gurrex.Common.Interfaces.Entities;
using Gurrex.Common.Interfaces.Repositories.Base;

namespace Gurrex.Common.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий работы с сущностью, реализующей интерфейс <see cref="IEntity"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IEntity"/></typeparam>
    public interface IRepositoryEntities<T> : IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Получить экземпляр сущности по Id
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <returns>Полученный экземпляр сущности</returns>
        T GetEntityById(Guid id);

        /// <summary>
        /// Получить последний добавленный экземпляр сущности
        /// </summary>
        /// <returns>Последний добавленный экземпляр сущности</returns>
        T GetLastEntity();

        /// <summary>
        /// Добавить экземпляр сущности
        /// </summary>
        /// <param name="entity">Добавляемый экземпляр сущности</param>
        /// <returns>True - сущность успешно добавлена, False - сущность не добавлена</returns>
        bool AddEntity(T entity);

        /// <summary>
        /// Обновить экземпляр сущности
        /// </summary>
        /// <param name="entity">Обновляемый экземпляр сущности</param>
        /// <returns>True - сущность успешно обновлена, False - сущность не обновлена</returns>
        bool UpdateEntity(T entity);

        /// <summary>
        /// Удалить экземпляр сущности по Id
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <returns>True - сущность удалена, False - сущность не удалена</returns>
        bool RemoveEntityById(Guid id);

        /// <summary>
        /// Сохранить изменения в базу
        /// </summary>
        /// <returns>True - изменения сохранены, Fales - изменения не сохранены</returns>
        bool SaveChanges();
    }
}
