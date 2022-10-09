using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GurrexTelegramBot.DAL.Entityes.Base;

namespace GurrexTelegramBot.DAL.Entityes
{
    /// <summary>
    /// Уведомления
    /// </summary>
    public class Notes : Entity
    {
        /// <summary>
        /// Заголовок уведомления
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Текст уведомления
        /// </summary>
        public string TextNote { get; set; } = null!;

        /// <summary>
        /// Дата срабатывания уведомления
        /// </summary>
        public DateTime DateNote { get; set; }

        /// <summary>
        /// Повтор уведомления каждую неделю
        /// </summary>
        public bool RepeatEveryWeek { get; set; }

        /// <summary>
        /// Повтор уведомления каждый день
        /// </summary>
        public bool RepeatEveryDay { get; set; }

        /// <summary>
        /// Активность уведомления
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public Guid ChatUserId { get; set; }
        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public virtual ChatUser ChatUser { get; set; }
    }
}
