using Gurrex.Common.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using YouTubeVideoDownloader.Interfaces.Entities;
using System.Reflection;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Картинка на видео
    /// </summary>
    public class Image : Entity, IImage
    {
        /// <summary>
        /// Массив байтов картинки
        /// </summary>
        [Column("ImageBytes", Order = 4)]
        public byte[] ImageBytes { get; set; } = null!;

        /// <summary>
        /// Расширение картинки
        /// </summary>
        [Column("Extention", Order = 5)]
        public string Extention { get; set; } = null!;

        /// <summary>
        /// Разрешение картинки
        /// </summary>
        [Column("Resolution", Order = 6)]
        public string Resolution { get; set; } = null!; 

        /// <summary>
        /// Внешний ключ YouTubeInfo
        /// </summary>
        public Guid YouTubeInfoId { get; set; }

        /// <summary>
        /// Информация о потоке
        /// </summary>
        public YouTubeInfo YouTubeInfo { get; set; } = null!;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Image()
        {
            Assembly = Assembly.GetExecutingAssembly();
            ResourcesPath = $"{Assembly.FullName}.Resources.Entities.Image";
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="imageBytes">Массив байтов картинки</param>
        /// <param name="extention">Расширение</param>
        /// <param name="resolution">Разрешение</param>
        public Image(Guid id, DateTime dateAdded, DateTime dateModified, DateTime dateDeleted, byte[] imageBytes, string extention, string resolution)
            : base(id, dateAdded, dateModified, dateDeleted)
        {
            ImageBytes = imageBytes;
            Extention = extention;
            Resolution = resolution;
        }


    }
}
