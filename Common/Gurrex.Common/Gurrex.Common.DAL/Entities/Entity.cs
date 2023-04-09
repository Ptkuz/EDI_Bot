using Gurrex.Common.Interfaces;
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
    public class Entity : IEntity, IAssemblyInfo
    {
        /// <summary>
        /// Экземпляр сборки
        /// </summary>
        [NotMapped]
        public Assembly Assembly { get; set; }

        /// <summary>
        /// Полное имя сборки
        /// </summary>
        [NotMapped]
        public AssemblyName FullAssemblyName { get; set; }

        /// <summary>
        /// Имя сборки
        /// </summary>
        [NotMapped]
        public string? AssemblyName { get; set; }

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
        public Entity()
        {
            Assembly = Assembly.GetExecutingAssembly();
            FullAssemblyName = Assembly.GetName();
            AssemblyName = FullAssemblyName.Name;
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        public Entity(Guid id, DateTime dateAdded, DateTime dateModified, DateTime dateDeleted) 
            : this()
        {
            Id = id;
            DateAdded = dateAdded;
            DateModified = dateModified;
            DateDeleted = dateDeleted;            
        }

        /// <summary>
        /// Получить путь до ресурсов
        /// </summary>
        /// <returns>Путь до ресурсов</returns>
        public virtual string GetResourcesPath(bool callBase = false) 
        {
            return $"{AssemblyName}.Resources.Entities.Entity";
        }

        /// <summary>
        /// Информация о сущности, реализующей интерфейс <see cref="IEntity"/>
        /// </summary>
        /// <returns>Информация о сущности</returns>
        public override string ToString()
        {
            string localizationString = LocalizationString.GetString(GetResourcesPath(), Assembly, "EntityInfo");
            return LocalizationString.GetResultString(localizationString, Id);
        }
    }
}
