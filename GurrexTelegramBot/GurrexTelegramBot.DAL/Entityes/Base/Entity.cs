using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GurrexTelegramBot.Interfaces;

namespace GurrexTelegramBot.DAL.Entityes.Base
{
    /// <summary>
    /// Класс базовой сущности
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// Id сущности
        /// </summary>
        public Guid Id { get; set; }
    }
}
