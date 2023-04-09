using Gurrex.Common.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using YouTubeVideoDownloader.Interfaces.Entities;
using System.Reflection;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Поток
    /// </summary>
    public class YouTubeInfo : Entity, IYouTubeInfo
    {
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
        public int Duration { get; set; }

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
        /// <param name="title">Заголовок видео</param>
        /// <param name="url">Ссылка на видео</param>
        /// <param name="duration">Длина видео</param>
        public YouTubeInfo(Guid id, DateTime dateAdded, DateTime dateModified, DateTime dateDeleted, string title, string url, int duration)
            : base(id, dateAdded, dateModified, dateDeleted)
        {
            Title = title;
            Url = url;
            Duration = duration;
        }

        /// <summary>
        /// Получить путь до ресурсов
        /// </summary>
        /// <returns>Путь до ресурсов</returns>
        public override string GetResourcesPath(bool callBase)
        {
            return $"{AssemblyName}.Resources.Entities.YouTubeInfo"; 
        }
    }
}
