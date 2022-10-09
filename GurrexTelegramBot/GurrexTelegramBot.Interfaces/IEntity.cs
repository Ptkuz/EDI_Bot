using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurrexTelegramBot.Interfaces
{
    /// <summary>
    /// Интерфейс базовой сущности
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id сущности
        /// </summary>
        Guid Id { get; set; }
    }
}
