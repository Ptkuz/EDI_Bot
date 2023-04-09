using Gurrex.Common.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using YouTubeVideoDownloader.Interfaces.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Видео поток
    /// </summary>
    public class Video : Entity, IVideo
    {

        /// <summary>
        /// Формат
        /// </summary>
        [Column("FormatVideo", Order = 4)]
        public string FormatVideo { get; set; } = null!;

        /// <summary>
        /// Разрешение
        /// </summary>
        [Column("Resolution", Order = 5)]
        public string Resolution { get; set; } = null!;


        /// <summary>
        /// Количество кадров в секунду (FPS)
        /// </summary>
        [Column("FrameRate", Order = 6)]
        public string FrameRate { get; set; } = null!;

        /// <summary>
        /// Формат аудио
        /// </summary>
        [Column("FormatAudio", Order = 7)]
        public string FormatAudio { get; set; } = null!;

        /// <summary>
        /// Битрейт аудио
        /// </summary>
        [Column("Bitrate", Order = 8)]
        public string Bitrate { get; set; } = null!;


        /// <summary>
        /// YouTube поток
        /// </summary>
        public YouTubeInfo YouTubeInfo { get; set; } = null!;

        /// <summary>
        /// Информация о видео на сервере
        /// </summary>
        public ServerInfo ServerInfo { get; set; } = null!;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Video()
        {
            Assembly = Assembly.GetExecutingAssembly();
            FullAssemblyName = Assembly.GetName();
            AssemblyName = FullAssemblyName.Name;
        }

        /// <summary>
        /// Инициализатор конструктор
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="formatVideo">Формат видео</param>
        /// <param name="resolution">Разрешение</param>
        /// <param name="frameRate">Количество кадров в секунду</param>
        /// <param name="formatAudio">Формат аудио</param>
        /// <param name="bitrate">Битрейт</param>
        public Video(Guid id, DateTime dateAdded, DateTime dateModified, DateTime dateDeleted, string formatVideo, string resolution, string frameRate, string formatAudio, string bitrate)
            : base(id, dateAdded, dateModified, dateDeleted)
        {
            FormatVideo = formatVideo;
            Resolution = resolution;
            FrameRate = frameRate;
            FormatAudio = formatAudio;
            Bitrate = bitrate;
        }

        /// <summary>
        /// Получить путь до ресурсов
        /// </summary>
        /// <returns>Путь до ресурсов</returns>
        public override string GetResourcesPath(bool callBase)
        {
            return $"{AssemblyName}.Resources.Entities.Video";
        }

    }
}
