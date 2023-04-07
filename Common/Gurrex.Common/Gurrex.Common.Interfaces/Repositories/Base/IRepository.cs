using Gurrex.Common.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Interfaces.Repositories.Base
{
    /// <summary>
    /// Базовый репозиторий работы с сущностью, реализующей интерфейс <see cref="IEntity"/>
    /// </summary>
    /// <typeparam name="T">Сущность, реализующая интерфейс <see cref="IEntity"/></typeparam>
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Получить все экземпляры сущности, унаследованной от <see cref="IEntity"/>
        /// </summary>
        IQueryable<T> Items { get; }

    }
}
