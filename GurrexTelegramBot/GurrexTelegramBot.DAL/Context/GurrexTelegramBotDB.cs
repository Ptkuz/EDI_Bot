using GurrexTelegramBot.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurrexTelegramBot.DAL.Context
{

    /// <summary>
    /// Контекст базы данных бота
    /// </summary>
    public class GurrexTelegramBotDB : DbContext
    {
        /// <summary>
        /// Набор сущностей пользователей чата
        /// </summary>
        public DbSet<ChatUser> ChatUsers { get; set; } = null!;

        /// <summary>
        /// Набор сущностей уведомлений
        /// </summary>
        public DbSet<Note> Notes { get; set; } = null!;

        /// <summary>
        /// Набор сущностей администраторов бота
        /// </summary>
        public DbSet<AdminUser> AdminUsers { get; set; } = null!;


        /// <summary>
        /// Создает и подключается к базе данных
        /// </summary>
        /// <param name="dbContextOptions">Настройки подключения</param>
        public GurrexTelegramBotDB(DbContextOptions<GurrexTelegramBotDB> dbContextOptions) :
            base(dbContextOptions) 
        {
            Database.EnsureCreated();
        }


    }
}
