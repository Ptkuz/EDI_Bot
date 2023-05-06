using Gurrex.Common.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using YouTubeVideoDownloader.Interfaces.Entities;
using System.Reflection;
using Gurrex.Common.Helpers;
using Gurrex.Common.Validations;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Информация о файле на сервере
    /// </summary>
    public class ServerInfo : Entity, IServerInfo
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
                return $"{StaticHelpers.GetAssemblyInfo().Assembly}.Resources.Entities.ServerInfo";
            }
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
        public int Size { get; set; }

        /// <summary>
        /// Внешний ключ Video
        /// </summary>
        public Guid VideoId { get; set; }

        /// <summary>
        /// Видео
        /// </summary>
        public Video Video { get; set; } = null!;

        /// <summary>
        /// Внешний ключ Audio
        /// </summary>
        public Guid AudioId { get; set; }

        /// <summary>
        /// Аудио
        /// </summary>
        public Audio Audio { get; set; } = null!;

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
        public ServerInfo(Guid id, DateTime dateAdded, DateTime dateModified, DateTime dateDeleted, string reference, int size)
            : base(id, dateAdded, dateModified, dateDeleted)
        {
            Ref = reference;
            Size = size;
        }
    }
}
