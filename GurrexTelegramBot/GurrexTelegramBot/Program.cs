using GurrexTelegramBot;
using GurrexTelegramBot.DAL;
using GurrexTelegramBot.DAL.Context;
using GurrexTelegramBot.DAL.Entityes;
using GurrexTelegramBot.Data;
using GurrexTelegramBot.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

class Program 
{

    IRepository<ChatUser> _chatUserRepository;
    static void Main() 
    {
        Startup startup = new Startup();
        startup.OnStartup();
            IRepository<ChatUser> chatUserRepository = new DbRepository<ChatUser>();

        BotConnection botConnection = new BotConnection();
        botConnection.EstablishConnection();
        Console.ReadLine();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) 
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices(Startup.ConfigureServices);

    }

   
}