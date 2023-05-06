using Gurrex.Common.Helpers;
using Gurrex.Common.Interfaces;
using YouTubeVideoDownloader.Interfaces.Models.Base;
using YouTubeVideoDownloader.YouTubeDataOperations.Models.Request;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.Base
{
    /// <summary>
    /// Базовая модель
    /// </summary>
    public class BaseModel : IBaseModel, IResources
    {
        /// <summary>
        /// Тип, который обращается к свойству <see cref="ResourcesPath"/>
        /// </summary>
        public virtual string? TypeName { get; set; } = null!;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public virtual string ResourcesPath 
        {
            get => $"{StaticHelpers.GetAssemblyInfo().AssemblyName.Name}.Resources.Base.BaseModel";
        }

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
