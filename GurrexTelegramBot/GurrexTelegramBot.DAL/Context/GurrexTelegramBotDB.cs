using GurrexTelegramBot.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurrexTelegramBot.DAL.Context
{
    public class GurrexTelegramBotDB : DbContext
    {
        public DbSet<ChatUser> ChatUsers { get; set; } = null!;
        public DbSet<Notes> Notes { get; set; } = null!;

        public GurrexTelegramBotDB(DbContextOptions<GurrexTelegramBotDB> dbContextOptions) :
            base(dbContextOptions) 
        {
            
        }


    }
}
