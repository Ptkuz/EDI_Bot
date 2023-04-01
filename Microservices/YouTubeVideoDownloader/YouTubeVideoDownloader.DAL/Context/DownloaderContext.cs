using Microsoft.EntityFrameworkCore;
using YouTubeVideoDownloader.DAL.Entities;

namespace YouTubeVideoDownloader.DAL.Context
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class DownloaderContext : DbContext
    {
        /// <summary>
        /// Каналы
        /// </summary>
        public DbSet<Channel> Channels { get; set; } = null!;

        /// <summary>
        /// Картинки
        /// </summary>
        public DbSet<Image> Images { get; set; } = null!;

        /// <summary>
        /// Видео
        /// </summary>
        public DbSet<Video> Videos { get; set; } = null!;

        public DownloaderContext()
        {

        }

        public DownloaderContext(DbContextOptions<DownloaderContext> options) :
            base(options)
        {
            Database.EnsureCreated();
        }
    }
}
