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
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<ChatUser>, DbRepository<ChatUser>>()
            .AddTransient<IRepository<Notes>, DbRepository<Notes>>()
            ;
    }
}
