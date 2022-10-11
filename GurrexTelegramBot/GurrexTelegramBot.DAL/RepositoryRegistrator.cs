using GurrexTelegramBot.DAL.Entityes;
using GurrexTelegramBot.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurrexTelegramBot.DAL
{
    /// <summary>
    /// Регистрация репозиториев
    /// </summary>
    public static class RepositoryRegistrator
    {
        /// <summary>
        /// Зарегистрировать репозитории
        /// </summary>
        /// <param name="services">расширение для <see cref="IServiceCollection"/></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<AdminUser>, DbRepository<AdminUser>>()
            .AddTransient<IRepository<ChatUser>, DbRepository<ChatUser>>()
            .AddTransient<IRepository<Note>, DbRepository<Note>>()
            ;
    }
}
