using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GurrexTelegramBot.DAL.Entityes.Base;

namespace GurrexTelegramBot.DAL.Entityes
{
    /// <summary>
    /// Сущность уведомления
    /// </summary>
    public class Note : Entity
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

        public Note() { }

        /// <summary>
        /// Создание нового уведомления
        /// </summary>
        /// <param name="id">Id уведомления</param>
        /// <param name="title">Заголовок уведомления</param>
        /// <param name="textNote">Текст уведомления</param>
        /// <param name="dateNote">Дата уведомления</param>
        /// <param name="repeatEveryWeek">Повторять ли каждую неделю</param>
        /// <param name="repeatEveryDay">Повторять ли каждый день</param>
        /// <param name="isActive">Активность</param>
        /// <param name="chatUserId">Id чата пользователя</param>
        public Note(Guid id, string title, string textNote, DateTime dateNote, bool repeatEveryWeek, bool repeatEveryDay,
            bool isActive, Guid chatUserId) : base(id)
        {
            Title = title;
            TextNote = textNote;
            DateNote = dateNote;
            RepeatEveryWeek = repeatEveryWeek;
            RepeatEveryDay = repeatEveryDay;
            IsActive = isActive;
            ChatUserId = chatUserId;
        }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public virtual ChatUser ChatUser { get; set; }
    }
}
