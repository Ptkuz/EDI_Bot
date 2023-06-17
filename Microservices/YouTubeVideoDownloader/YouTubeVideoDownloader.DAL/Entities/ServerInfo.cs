using Gurrex.Common.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Gurrex.Common.Helpers;
using Gurrex.Common.Validations;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Информация о файле на сервере
    /// </summary>
    public class ServerInfo : Entity, IServerInfo
    {

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        [NotMapped]
        public override string ResourcesPath
        {
            get => $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Entities.ServerInfo";
        }

        /// <summary>
        /// Ссылка на файл
        /// </summary>
        [Column("Ref", Order = 4)]
        public string Ref { get; set; } = null!;

        /// <summary>
        /// Размер файла
        /// </summary>
        [Column("Size", Order = 5)]
        public long Size { get; set; }

        /// <summary>
        /// Внешний ключ Video
        /// </summary>
        public Guid? VideoId { get; set; }

        /// <summary>
        /// Видео
        /// </summary>
        public Video? Video { get; set; }

        /// <summary>
        /// Внешний ключ Audio
        /// </summary>
        public Guid? AudioId { get; set; }

        /// <summary>
        /// Аудио
        /// </summary>
        public Audio? Audio { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ServerInfo()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="reference">Ссылка на видео</param>
        /// <param name="size">Размер видео</param>
        private ServerInfo(string reference, long size)
            : base()
        {
            Ref = reference;
            Size = size;
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="reference">Ссылка на видео</param>
        /// <param name="size">Размер видео</param>
        private ServerInfo(Guid id, string reference, long size)
            : base(id)
        {
            Ref = reference;
            Size = size;
        }

        public ServerInfo(Guid id, string reference, long size, Audio audio) 
            : this(id, reference, size)
        {
            Audio = audio;
        }

        public ServerInfo(Guid id, string reference, long size, Video video)
            : this(id, reference, size)
        {
            Video = video;
        }

        public ServerInfo(string reference, long size, Audio audio) :
            this(reference, size)
        {
            Audio = audio;
        }

        public ServerInfo(string reference, long size, Video video) :
            this(reference, size)
        {
            Video = video;
        }

    }
}
