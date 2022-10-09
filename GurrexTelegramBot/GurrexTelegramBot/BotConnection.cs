using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Configuration;
using GurrexTelegramBot.BotCommands;
using GurrexTelegramBot.Interfaces;
using GurrexTelegramBot.DAL.Entityes;

namespace GurrexTelegramBot
{
    /// <summary>
    /// Подключение бота
    /// </summary>
    public class BotConnection
    {
        static private string? _accessToken = ConfigurationManager.AppSettings["token"];
        private readonly TelegramBotClient _gurrexBot;
        private readonly Commands _commands;

        IRepository<ChatUser> _chatUserRepository;

        public BotConnection(IRepository<ChatUser> _chatUserRepository)
        {
            this._chatUserRepository = _chatUserRepository;

            if (_accessToken is null)
            {
                throw new ArgumentNullException("Некорректный токен доступа к боту!", nameof(_accessToken));
            }

            _gurrexBot = new TelegramBotClient(_accessToken);
            _commands = new Commands(_chatUserRepository);
            
        }

        /// <summary>
        /// Установка соединения с Telegram
        /// </summary>
        /// <returns></returns>
        public async Task EstablishConnection()
        {
            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new UpdateType[]
            {
                UpdateType.Message,
                UpdateType.EditedMessage,
            }
            };

            _gurrexBot.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync,
                receiverOptions, cts.Token);

            var gurrex = await _gurrexBot.GetMeAsync();

            Console.WriteLine($"Запущен бот @{gurrex.Username}");

            Console.ReadLine();
            cts.Cancel();
        }

       

        private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancel)
        {
            using var cts = new CancellationTokenSource();

            

            if (update.Message is not { } message)
            {
                return;
            }

            if (message.Text?.ToLower() is not { } messageText)
            {
                return;
            }

            var chatId = message.Chat.Id;
            var name = message.Chat.FirstName + message.Chat.LastName;

            Console.WriteLine($"Пользователь " +
                $"{message.Chat.Username ?? name ?? message.Chat.Id.ToString()}" +
                $" написал - {messageText}");

            switch (messageText)
            {
                case "start" or @"/start":
                    await _commands.StartCommand(chatId, _gurrexBot, cancel);
                    break;
                case "help" or @"/help":
                    await _commands.RatesCommand(chatId, _gurrexBot, cancel);
                    break;
                case "note" or @"/note":
                default:

                    break;
            }
        }

        private async static Task HandlePollingErrorAsync(ITelegramBotClient client, Exception error, CancellationToken cancel)
        {

        }
    }
}
