using Gurrex.Common.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using YouTubeVideoDownloader.Interfaces.Entities;
using System.Reflection;
using Gurrex.Common.Helpers;
using Gurrex.Common.Validations;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Канал на YouTube
    /// </summary>
    public class Channel : Entity, IChannel
    {

        /// <summary>
        /// Тип
        /// </summary>
        [NotMapped]
        public override string? TypeName { get; set; }

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        [NotMapped]
        public override string ResourcesPath
        {
            get
            {
                return $"{StaticHelpers.GetAssemblyInfo().Assembly}.Resources.Entities.Channel";
            }
        }

        /// <summary>
        /// Название канала
        /// </summary>
        [Column("Name", Order = 4)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Коллекция YouTube потоков
        /// </summary>
        public IQueryable<YouTubeInfo> YouTubeInfos { get; set; } = null!;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Channel() 
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="name">Название канала</param>
        public Channel(Guid id, DateTime dateAdded, DateTime dateModified, DateTime dateDeleted, string name) 
            : base(id, dateAdded, dateModified, dateDeleted)
        {
            Name = name;
        }
    }
}
