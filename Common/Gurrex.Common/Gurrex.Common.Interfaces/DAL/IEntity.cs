namespace Gurrex.Common.Interfaces.Entities
{
    /// <summary>
    /// Интерфейс сущности
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id сущности с типом
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Дата добавления
        /// </summary>
        DateTime DateAdded { get; set; }

        /// <summary>
        /// Дата последней модификации
        /// </summary>
        DateTime DateModified { get; set; }

        /// <summary>
        /// Дата удаления
        /// </summary>
        DateTime? DateDeleted { get; set; }

    }
}
