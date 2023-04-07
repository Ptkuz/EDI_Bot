using Gurrex.Common.DAL.Base;
using Gurrex.Common.Interfaces.Entities;
using Gurrex.Common.Localization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Gurrex.Common.DAL.Entities
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public class Entity : BaseDAL, IEntity
    {
        /// <summary>
        /// Id сущности
        /// </summary>
        [Key]
        [Column("Id", Order = 0)]
        public Guid Id { get; set; }

        /// <summary>
        /// Дата добавления
        /// </summary>
        [Column("DateAdded", Order = 1)]
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        [Column("DateModified", Order = 2)]
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Дата удаления
        /// </summary>
        [Column("DateDeleted", Order = 3)]
        public DateTime? DateDeleted { get; set; }

        /// <summary>
        /// Инициализатор информации о сборке
        /// </summary>
        private Entity(Assembly currentAssembly, string resourcesPath) 
            : base() 
        {
            _resourcesPath = $"{_resourcesPath}.Entities.Entity";
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="currentAssembly">Текущая сборка</param>
        /// <param name="resourcesPath">Путь до ресурсов</param>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        public Entity(Assembly currentAssembly, string resourcesPath, Guid id, DateTime dateAdded, DateTime dateModified, DateTime dateDeleted) 
            : this(currentAssembly, resourcesPath)
        {
            Id = id;
            DateAdded = dateAdded;
            DateModified = dateModified;
            DateDeleted = dateDeleted;

            string localizationString = LocalizationString.GetString(_resourcesPath, _currentAssembly, "EntityConstructorInit");
            
        }

        /// <summary>
        /// Информация о сущности, реализующей интерфейс <see cref="IEntity"/>
        /// </summary>
        /// <returns>Информация о сущности</returns>
        public override string ToString()
        {
            string localizationString = LocalizationString.GetString(_resourcesPath, _currentAssembly, "EntityInfo");
            return LocalizationString.GetResultString(localizationString, Id);
        }
    }
}
