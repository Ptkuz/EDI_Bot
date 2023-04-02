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
        /// Потоки
        /// </summary>
        public DbSet<Info> Infos { get; set; } = null!;

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
                .HasOne(x => x.Info)
                .WithMany(x => x.Audios)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Video>()
               .HasOne(x => x.Info)
               .WithMany(x => x.Videos)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Info>()
                .HasOne(x => x.Channel)
                .WithMany(x => x.Infos)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Image>()
               .HasOne(u => u.Info)
               .WithOne(s => s.Image)
               .OnDelete(DeleteBehavior.Cascade)
               .HasForeignKey<Info>(m => m.ImageId);

            modelBuilder.Entity<ServerInfo>()
                .HasOne(x => x.Audio)
                .WithOne(x => x.ServerInfo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<Audio>(x => x.AudioId);

            modelBuilder.Entity<ServerInfo>()
                .HasOne(x => x.Video)
                .WithOne(x => x.ServerInfo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<Video>(x => x.VideoId);
        }
    }
}
