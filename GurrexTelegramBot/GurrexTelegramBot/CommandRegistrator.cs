using Microsoft.Extensions.DependencyInjection;
using GurrexTelegramBot.BotCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurrexTelegramBot
{
    public static class CommandRegistrator
    {
        public static IServiceCollection AddCommand(this IServiceCollection services) => services
            .AddTransient<ICommands, Commands>()
            ;
    }
}
