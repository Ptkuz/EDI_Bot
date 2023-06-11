using Gurrex.Common.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection;
using Gurrex.Common.Helpers;
using Gurrex.Common.Validations;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Channels;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Поток
    /// </summary>
    public class YouTubeInfo : Entity, IYouTubeInfo
    {

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        [NotMapped]
        public override string ResourcesPath
        {
            get => $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Entities.YouTubeInfo";
        }

        /// <summary>
        /// Заголовок
        /// </summary>
        [Column("Title", Order = 4)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Ссылка
        /// </summary>
        [Column("Url", Order = 5)]
        public string Url { get; set; } = null!;

        /// <summary>
        /// Продолжительность
        /// </summary>
        [Column("Duration", Order = 6)]
        public int? Duration { get; set; }

        /// <summary>
        /// Канал
        /// </summary>
        [ForeignKey("ChannelId")]
        public Channel Channel { get; set; } = null!;

        /// <summary>
        /// Картинка
        /// </summary>
        [ForeignKey("ImageId")]
        public Image Image { get; set; } = null!;

        /// <summary>
        /// Видео
        /// </summary>
        public IQueryable<Video> Videos { get; set; } = null!;

        /// <summary>
        /// Аудио
        /// </summary>
        public IQueryable<Audio> Audios { get; set; } = null!;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public YouTubeInfo()
            : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="logger">Логирование</param>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="title">Заголовок видео</param>
        /// <param name="url">Ссылка на видео</param>
        /// <param name="duration">Длина видео</param>
        public YouTubeInfo(string title, string url, int? duration, Channel channel, Image image)
            : base()
        {
            Title = title;
            Url = url;
            Duration = duration;
            Channel = channel;
            Image = image;

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="logger">Логирование</param>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="title">Заголовок видео</param>
        /// <param name="url">Ссылка на видео</param>
        /// <param name="duration">Длина видео</param>
        public YouTubeInfo(Guid id, string title, string url, int duration, Channel channel, Image image)
            : base(id)
        {
            Title = title;
            Url = url;
            Duration = duration;
            Channel = channel;
            Image = image;
        }
    }
}
