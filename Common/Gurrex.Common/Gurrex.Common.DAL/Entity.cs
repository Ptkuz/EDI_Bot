using Gurrex.Common.Helpers;
using Gurrex.Common.Helpers.Models;
using Gurrex.Common.Interfaces;
using Gurrex.Common.Interfaces.Entities;
using Gurrex.Common.Localization;
using Gurrex.Common.Localization.Models;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gurrex.Common.DAL.Entities
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public class Entity : IEntity, IResources<AssemblyInfo>
    {

        /// <summary>
        /// Сборка
        /// </summary>
        [NotMapped]
        public AssemblyInfo AssemblyInfo => StaticHelpers.GetAssemblyInfo();


        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        [NotMapped]
        public virtual string ResourcesPath
        {
            get => $"{AssemblyInfo.AssemblyName.Name}.Resources.EntityRepository";
        }

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
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="logger">Логирование</param>
        public Entity()
        {
            Id = Guid.NewGuid();
            DateAdded = DateTime.Now;
            DateModified = DateTime.Now;
            DateDeleted = null;
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="logger">Логирование</param>
        public Entity(Guid id)
        {
            Id = id;
            DateAdded = DateTime.Now;
            DateModified = DateTime.Now;
            DateDeleted = null;
        }


        /// <summary>
        /// Информация о сущности, реализующей интерфейс <see cref="IEntity"/>
        /// </summary>
        /// <returns>Информация о сущности</returns>
        public override string ToString()
        {
            string localizationString = ManagerResources.GetString(new Resource(ResourcesPath, "EntityInfo", AssemblyInfo.Assembly));
            string resultString = ManagerResources.GetResultString(localizationString, Id);
            return resultString;
        }
    }
}
