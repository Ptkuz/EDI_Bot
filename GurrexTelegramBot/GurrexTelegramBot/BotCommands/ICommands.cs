using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace GurrexTelegramBot.BotCommands
{
    public interface ICommands
    {
        Task StartCommand(long chatId, TelegramBotClient bot, CancellationToken cancellationToken);
        Task RatesCommand(long chatId, TelegramBotClient bot, CancellationToken cancellationToken);
    }
}
