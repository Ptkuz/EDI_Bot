using GurrexTelegramBot.DAL.Context;
using GurrexTelegramBot.DAL.Entityes.Base;
using GurrexTelegramBot.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GurrexTelegramBot.DAL
{

    /// <summary>
    /// Общий репозиторий для всех сущностей
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbRepository<T> : IRepository<T> where T : Entity, new()
    {

        private readonly DbContext _context;
        private readonly DbSet<T> _set;

        /// <summary>
        /// Инициализирует контекст базы данных
        /// </summary>
        /// <param name="db">Контекст базы данных бота</param>
        public DbRepository(GurrexTelegramBotDB db)
        {
            _context = db;
            _set = db.Set<T>();
        }

        /// <summary>
        /// Коллекция объектов сущности <see cref="T"/>
        /// </summary>
        public virtual IQueryable<T> Items => _set;


        /// <summary>
        /// Добавить новую сущность <see cref="T"/> в БД
        /// </summary>
        /// <param name="item">Добавляемая сущность</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>Добавленный объект</returns>
        /// <exception cref="ArgumentNullException">Добавляемый объект <see cref="T"/> пустой</exception>
        public async Task<T> AddAsync(T item, CancellationToken cancel)
        {
            if (item is null)
            {
                throw new ArgumentNullException("Добавляемый объект пустой", nameof(item));
            }

            await _context.AddAsync(item);
            return item;

        }

        /// <summary>
        /// Получить объект <see cref="T"/> по Id
        /// </summary>
        /// <param name="id">Id объекта <see cref="T"/></param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>Полученный объект</returns>
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancel)
        {
            T? item = await Items
                 .FirstOrDefaultAsync(item => item.Id == id, cancel)
                 .ConfigureAwait(false);
            return item;

        }

        /// <summary>
        /// Удалить объект <see cref="T"/> из БД
        /// </summary>
        /// <param name="id">Id получаемого объекта</param>
        /// <param name="cancel">Токен отмены</param>
        /// <returns>Удаленный объект</returns>
        /// <exception cref="ArgumentNullException">Не найден удаляемый объект <see cref="T"/></exception>
        public async Task<T> RemoveAsync(Guid id, CancellationToken cancel)
        {
            T? deletedItem = await GetByIdAsync(id, cancel);

            if (deletedItem is null)
            {
                throw new ArgumentNullException("По указанному Id объект в базе не найден", nameof(deletedItem));
            }

            _context.Remove(deletedItem);
            return deletedItem;
        }

        /// <summary>
        /// Обновить объект <see cref="T"/> в БД
        /// </summary>
        /// <param name="item">Обновленный объект</param>
        /// <param name="cancel">Токен отмены</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Update(T item, CancellationToken cancel)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Entry(item).State = EntityState.Modified;
        }

    }
}
