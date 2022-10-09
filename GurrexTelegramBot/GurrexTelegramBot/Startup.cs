using GurrexTelegramBot.BotCommands;
using GurrexTelegramBot.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurrexTelegramBot
{
    public class Startup
    {
        static string connection =
    System.Configuration.ConfigurationManager.
    ConnectionStrings["defaultConnection"].ConnectionString;

        private static IHost? _host;

        public static IHost Host => _host
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        private static IServiceProvider Services => Host.Services;

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
        .AddDataBase(connection)
        .AddCommand();


        public async void OnStartup() 
        {
            var host = Host;

            using (var scope = Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();
                //scope.ServiceProvider.GetRequiredService<BotCommands.Commands>().FirstCommand().Wait();
                scope.ServiceProvider.GetRequiredService<Commands>();
            }

            await host.StartAsync();
        }

        public async void OnExit() 
        {
            using (var host = Host)
            {
                await host.StopAsync();
            }
        }


    }
}
