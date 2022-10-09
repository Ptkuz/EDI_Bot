using GurrexTelegramBot.DAL.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurrexTelegramBot.DAL.Entityes
{
    /// <summary>
    /// Информация о чате пользователя
    /// </summary>
    public class ChatUser : Entity
    {

        public long ChatId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public virtual List<Notes> Notes { get; set; } = new List<Notes>();
    }
}
