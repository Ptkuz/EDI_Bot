namespace GurrexTelegramBot.Interfaces
{
    /// <summary>
    /// Репозиторий для работы с данными
    /// </summary>
    /// <typeparam name="T">Объект</typeparam>
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Список объектов
        /// </summary>
        IQueryable<T> Items { get; }

        /// <summary>
        /// Получить объект по Id
        /// </summary>
        /// <param name="id">Id объекта</param>
        /// <param name="cancel">Отмена операции</param>
        /// <returns>Полученный объект</returns>
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancel);

        /// <summary>
        /// Добавление объекта
        /// </summary>
        /// <param name="item">Добавляемый объект</param>
        /// <param name="cancel">Отмена операции</param>
        /// <returns>Добавленный объект</returns>
        Task<T> AddAsync(T item, CancellationToken cancel);

        /// <summary>
        /// Обновление объекта
        /// </summary>
        /// <param name="item">Обновляемый объект</param>
        /// <param name="cancel">Отмена операции</param>
        /// <returns>Обновленный объект</returns>
        void Update(T item, CancellationToken cancel);

        /// <summary>
        /// Удаление объекта
        /// </summary>
        /// <param name="id">Id объекта</param>
        /// <param name="cancel">Отмена операции</param>
        /// <returns>Удаленный объект</returns>
        Task<T> RemoveAsync(Guid id, CancellationToken cancel);


    }
}
