using GurrexTelegramBot.DAL;
using GurrexTelegramBot.DAL.Context;
using GurrexTelegramBot.DAL.Entityes;
using GurrexTelegramBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace GurrexTelegramBot.BotCommands
{
    public class Commands : ICommands
    {

        private IRepository<ChatUser> _chatUserRepository;

        public Commands(IRepository<ChatUser> chatUserRepository) 
        {
            _chatUserRepository = chatUserRepository;
        }


        public async Task StartCommand(long chatId, TelegramBotClient bot, CancellationToken cancellationToken) 
        {

            var users = _chatUserRepository.Items;

            


                Message message = await bot.SendTextMessageAsync
                    (chatId, "Добро пожаловать! Вот это я умею:");
            await RatesCommand(chatId, bot, cancellationToken);
            
        }

        public async Task RatesCommand(long chatId, TelegramBotClient bot, CancellationToken cancellationToken) 
        {
            var commands = await bot.GetMyCommandsAsync();
            StringBuilder stringCommands = new StringBuilder();
            foreach (var command in commands)
            {
                string commandInfo = $"{command.Command} - {command.Description}\n";
                stringCommands.Append(commandInfo);
            }
            Message messageCommands = await bot.SendTextMessageAsync(chatId, stringCommands.ToString());
        }

       
    }
}
