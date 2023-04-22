using YouTubeVideoDownloader.Interfaces.Models;
using YouTubeVideoDownloader.Interfaces.Models.Response;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.Response
{
    /// <summary>
    /// Общая главная информация о видео
    /// </summary>
    public class MainInfoResponse : IMainInfoResponse
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
        public MainInfoResponse(string title, string author, int? duration)
        {
            Title = title;
            Author = author;
            Duration = duration;
        }
    }
}
