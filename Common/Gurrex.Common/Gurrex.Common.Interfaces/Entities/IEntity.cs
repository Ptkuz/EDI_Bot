using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Interfaces.Entities
{
    /// <summary>
    /// Интерфейс сущности
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id сущности с типом <see cref="Guid"/>
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Дата добавления
        /// </summary>
        DateTime DateAdded { get; set; }

        /// <summary>
        /// Дата последней модификации
        /// </summary>
        DateTime DateModified { get; set; }

        /// <summary>
        /// Дата удаления
        /// </summary>
        DateTime? DateDeleted { get; set; }

    }
}
