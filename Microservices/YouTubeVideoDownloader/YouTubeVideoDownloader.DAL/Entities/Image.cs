using Gurrex.Common.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Gurrex.Common.Helpers;
using Gurrex.Common.Validations;
using Microsoft.Extensions.Logging;
using YouTubeVideoDownloader.Interfaces.DAL.Entities;

namespace YouTubeVideoDownloader.DAL.Entities
{
    /// <summary>
    /// Картинка на видео
    /// </summary>
    public class Image : Entity, IImage
    {

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        [NotMapped]
        public override string ResourcesPath
        {
            get => $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Entities.Image";
        }

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
        /// Конструктор инициализатор
        /// </summary>
        public Image()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="logger">Id сущности</param>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="imageBytes">Массив байтов картинки</param>
        /// <param name="extention">Расширение</param>
        /// <param name="resolution">Разрешение</param>
        public Image(byte[] imageBytes, string extention, string resolution, YouTubeInfo youTubeInfo)
            : base()
        {
            ImageBytes = imageBytes;
            Extention = extention;
            Resolution = resolution;
            YouTubeInfo = youTubeInfo;
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="logger">Id сущности</param>
        /// <param name="id">Id сущности</param>
        /// <param name="dateAdded">Дата добавления</param>
        /// <param name="dateModified">Дата изменения</param>
        /// <param name="dateDeleted">Дата удаления</param>
        /// <param name="imageBytes">Массив байтов картинки</param>
        /// <param name="extention">Расширение</param>
        /// <param name="resolution">Разрешение</param>
        public Image(Guid id, byte[] imageBytes, string extention, string resolution, YouTubeInfo youTubeInfo)
            : base(id)
        {
            ImageBytes = imageBytes;
            Extention = extention;
            Resolution = resolution;
            YouTubeInfo = youTubeInfo;  
        }

    }
}
