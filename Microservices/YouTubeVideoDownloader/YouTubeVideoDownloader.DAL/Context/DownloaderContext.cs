using Microsoft.EntityFrameworkCore;
using YouTubeVideoDownloader.DAL.Entities;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.DAL.Context
{
    /// <summary>
    /// Контекст базы данных сервиса скачивания видео с YouTube
    /// </summary>
    public class DownloaderContext : DbContext
    {
        /// <summary>
        /// Информация о потоке с YouTube
        /// </summary>
        public DbSet<YouTubeInfo> YouTubeInfos { get; set; } = null!;

        /// <summary>
        /// Информация о файле на сервере
        /// </summary>
        public DbSet<ServerInfo> ServerInfos { get; set; } = null!;

        /// <summary>
        /// Аудио
        /// </summary>
        public DbSet<Audio> Audios { get; set; } = null!;

        /// <summary>
        /// Видео
        /// </summary>
        public DbSet<Video> Videos { get; set; } = null!;

        /// <summary>
        /// Каналы
        /// </summary>
        public DbSet<Channel> Channels { get; set; } = null!;

        /// <summary>
        /// Картинки
        /// </summary>
        public DbSet<Image> Images { get; set; } = null!;


        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public DownloaderContext()
        {

        }

        /// <summary>
        /// Инициализация базы данных
        /// </summary>
        /// <param name="options">Настройки подключения</param>
        public DownloaderContext(DbContextOptions<DownloaderContext> options) :
            base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audio>()
                .HasOne(x => x.YouTubeInfo)
                .WithMany(x => x.Audios)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Video>()
               .HasOne(x => x.Info)
               .WithMany(x => x.Videos)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<YouTubeInfo>()
                .HasOne(x => x.Channel)
                .WithMany(x => x.YouTubeInfos)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<YouTubeInfo>()
               .HasOne(u => u.Image)
               .WithOne(s => s.YouTubeInfo)
               .OnDelete(DeleteBehavior.Cascade)
               .HasForeignKey<Image>(m => m.YouTubeInfoId);

            modelBuilder.Entity<Audio>()
                .HasOne(x => x.ServerInfo)
                .WithOne(x => x.Audio)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey<ServerInfo>(x => x.AudioId);

            modelBuilder.Entity<Video>()
                .HasOne(x => x.ServerInfo)
                .WithOne(x => x.Video)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey<ServerInfo>(x => x.VideoId);
        }
    }
}
