using GurrexTelegramBot.DAL;
using GurrexTelegramBot.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GurrexTelegramBot.BotCommands;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurrexTelegramBot.Data
{
    public static class DbRegistrator
    {

        public static IServiceCollection AddDataBase(this IServiceCollection services, string connnectionString) => services
            .AddDbContext<GurrexTelegramBotDB>(opt => 
            {

                opt
                .UseLazyLoadingProxies()
                .UseSqlServer(connnectionString);
            })
            .AddTransient<DbInitializer>()
            .AddTransient<Commands>()
            .AddRepositoriesInDB();
    }
}
