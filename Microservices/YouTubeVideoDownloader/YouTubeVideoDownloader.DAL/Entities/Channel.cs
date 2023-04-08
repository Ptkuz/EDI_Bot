using Gurrex.Common.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using YouTubeVideoDownloader.Interfaces.Entities;
using System.Reflection;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Канал на YouTube
    /// </summary>
    public class Channel : Entity, IChannel
    {

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
            Assembly = Assembly.GetExecutingAssembly();
            ResourcesPath = $"{Assembly.FullName}.Resources.Entities.Channel";
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
