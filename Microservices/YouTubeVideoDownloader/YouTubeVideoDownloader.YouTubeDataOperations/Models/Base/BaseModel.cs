using YouTubeVideoDownloader.Interfaces.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.Base
{
    /// <summary>
    /// Базовая модель
    /// </summary>
    public class BaseModel : IBaseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        public BaseModel() 
        {
            Id = Guid.NewGuid();
        }
    }
}
