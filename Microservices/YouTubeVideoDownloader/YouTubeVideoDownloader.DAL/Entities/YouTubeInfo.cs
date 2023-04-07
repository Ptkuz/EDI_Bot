using Gurrex.Common.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using YouTubeVideoDownloader.Interfaces.Entities;

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
    }
}
