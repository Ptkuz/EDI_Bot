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
        T GetEntityById(Guid id);

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
        T AddEntity(T entity);

        /// <summary>
        /// Обновить сущность <see cref="T"/>
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        /// <returns>True - сущность успешно обновлена, False - сущность не обновлена</returns>
        T UpdateEntity(T entity);

        /// <summary>
        /// Удаление сущности по Id
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns></returns>
        bool RemoveEntityById(Guid id);

        /// <summary>
        /// Сохранить изменения в базу
        /// </summary>
        /// <returns>True - изменения сохранены, Fales - изменения не сохранены</returns>
        bool SaveChanges();
    }
}
