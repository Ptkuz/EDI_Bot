using Gurrex.Common.DAL.Entities;
using System.Collections.Generic;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Поток
    /// </summary>
    public class Info : Entity, IInfo
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Канал
        /// </summary>
        public Channel Channel { get; set; } = null!;

        public Guid ImageId { get; set; }

        /// <summary>
        /// Картинка
        /// </summary>
        public Image Image { get; set; } = null!;

        /// <summary>
        /// Ссылка
        /// </summary>
        public string Url { get; set; } = null!;

        /// <summary>
        /// Продолжительность
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Видео
        /// </summary>
        public IQueryable<Video> Videos { get; set; } = null!;

        /// <summary>
        /// Аудио
        /// </summary>
        public IQueryable<Audio> Audios { get; set; } = null!;
    }
}
