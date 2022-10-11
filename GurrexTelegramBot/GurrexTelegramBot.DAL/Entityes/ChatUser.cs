using GurrexTelegramBot.DAL.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurrexTelegramBot.DAL.Entityes
{
    /// <summary>
    /// Информация пользователя
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

        public ChatUser() { }

        /// <summary>
        /// Создание нового пользователя чата
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="chatId">Id чата</param>
        /// <param name="username">Имя пользователя</param>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        public ChatUser(Guid id, long chatId, string? username, string? firstName, string? lastName) : base(id)
        {
            ChatId = chatId;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public virtual List<Note> Notes { get; set; } = new List<Note>();
    }
}
