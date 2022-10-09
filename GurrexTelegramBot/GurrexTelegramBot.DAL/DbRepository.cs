using GurrexTelegramBot.DAL.Context;
using GurrexTelegramBot.DAL.Entityes.Base;
using GurrexTelegramBot.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GurrexTelegramBot.DAL
{
    public class DbRepository<T> : IRepository<T> where T : Entity, new()
    {

        private readonly GurrexTelegramBotDB _db;
        private readonly DbSet<T> _set;

        public DbRepository(GurrexTelegramBotDB db) 
        {
            _db = db;
            //var items = _db.Notes.ToList();
        }

        public virtual IQueryable<T> Items => _set; 


        public async Task<T> AddAsync(T item, CancellationToken cancel)
        {
            if (item is null) 
            {
                throw new ArgumentNullException("Добавляемый объект пустой", nameof(item));
            }

            await _db.AddAsync(item);
            return item;
            
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancel)
        {
           T? item = await Items
                .FirstOrDefaultAsync(item => item.Id == id, cancel)
                .ConfigureAwait(false);
            return item;

        }

        public async Task<T> RemoveAsync(Guid id, CancellationToken cancel)
        {
            T? deletedItem = await GetByIdAsync(id, cancel);

            if (deletedItem is null) 
            {
                throw new ArgumentNullException("По указанному Id объект в базе не найден", nameof(deletedItem));
            }

            _db.Remove(deletedItem);
            return deletedItem;
        }

        public async Task UpdateAsync(T item, CancellationToken cancel)
        {
            if (item is null) 
            {
                throw new ArgumentNullException(nameof(item));
            }
            _db.Entry(item).State = EntityState.Modified;
        }

    }
}
