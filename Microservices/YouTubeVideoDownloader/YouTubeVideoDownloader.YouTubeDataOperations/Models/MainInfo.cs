using YouTubeVideoDownloader.Interfaces.Models;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models
{
    /// <summary>
    /// Общая главная информация о видео
    /// </summary>
    public class MainInfo : IMainInfo
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Автор
        /// </summary>
        public string Author { get; set; } = null!;

        /// <summary>
        /// Продолжительность в секундах
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="author">Автор</param>
        /// <param name="duration">Продолжительность в секундах</param>
        public MainInfo(string title, string author, int? duration) 
        {
            Title = title;
            Author = author;
            Duration = duration;
        }
    }
}
