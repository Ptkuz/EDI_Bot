using Gurrex.Common.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Interfaces.Repositories.Base
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями базы данных
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Получить все объекты сущности <see cref="T"/>
        /// </summary>
        IQueryable<T> Items { get; }

    }
}
