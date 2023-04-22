using Gurrex.Common.Interfaces.Entities;

namespace YouTubeVideoDownloader.Interfaces.Entities
{
    /// <summary>
    /// Информация о файле на сервере
    /// </summary>
    public interface IServerInfo : IEntity
    {
        /// <summary>
        /// Ссылка на файл
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// Размер файла
        /// </summary>
        public int Size { get; set; }
    }
}
