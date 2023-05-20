using Gurrex.Common.DAL.Entities;
using Gurrex.Common.Helpers;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Аудио поток
    /// </summary>
    public class Audio : Entity, IAudio
    {
        /// <summary>
        /// Логирование
        /// </summary>
        [NotMapped]
        private readonly ILogger<Audio> _logger = null!;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        [NotMapped]
        public override string ResourcesPath
        {
            get => $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Entities.Audio";   
        }


        /// <summary>
        /// Формат
        /// </summary>
        [Column("FormatAudio", Order = 4)]
        public string FormatAudio { get; set; } = null!;

        /// <summary>
        /// Битрейт
        /// </summary>
        [Column("Bitrate", Order = 5)]
        public string Bitrate { get; set; } = null!;

        /// <summary>
        /// YouTube поток
        /// </summary>
        [ForeignKey("YouTubeInfoId")]
        public YouTubeInfo YouTubeInfo { get; set; } = null!;

        /// <summary>
        /// Информация о аудио на сервере
        /// </summary>
        [ForeignKey("ServerInfoId")]
        public ServerInfo ServerInfo { get; set; } = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        public Audio() 
        {

        }

        /// <summary>
        /// Инициализатор конструктор
        /// </summary>
        /// <param name="logger">Логирование</param>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="formatAudio">Формат аудио</param>
        /// <param name="bitrate">Битрейт</param>
        public Audio(ILogger<Audio> logger, Guid id, DateTime dateAdded, DateTime dateModified, DateTime dateDeleted, string formatAudio, string bitrate)
            : base(logger, id, dateAdded, dateModified, dateDeleted)
        {
            _logger = logger;
            FormatAudio = formatAudio;
            Bitrate = bitrate;
        }


    }
}
