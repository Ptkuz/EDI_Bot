using GurrexTelegramBot.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurrexTelegramBot.Data
{
    public class DbInitializer
    {
        private readonly GurrexTelegramBotDB _db;

        public DbInitializer(GurrexTelegramBotDB db) 
        {
            _db = db;
        }

        public async Task InitializeAsync() 
        {
            await _db.Database.EnsureCreatedAsync().ConfigureAwait(false);
            //var item = _db.ChatUsers.ToList();
            //await _db.DisposeAsync();
        }
    }
}
