using Gurrex.Common.DAL.Entities;
using Gurrex.Common.Helpers;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Канал на YouTube
    /// </summary>
    public class Channel : Entity, IChannel
    {
        /// <summary>
        /// Логирование
        /// </summary>
        [NotMapped]
        private readonly ILogger<Channel> _logger = null!;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        [NotMapped]
        public override string ResourcesPath
        {
            get => $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Entities.Channel";
        }

        /// <summary>
        /// Название канала
        /// </summary>
        [Column("Name", Order = 4)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Коллекция YouTube потоков
        /// </summary>
        public List<YouTubeInfo> YouTubeInfos { get; set; } = new();

        /// <summary>
        /// Конструктор инициализатор
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
        public Channel(string name)
            : base()
        {
            Name = name;
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="name">Название канала</param>
        public Channel(ILogger<Channel> logger, Guid id, string name)
            : base(id)
        {
            _logger = logger;
            Name = name;
        }
    }
}
