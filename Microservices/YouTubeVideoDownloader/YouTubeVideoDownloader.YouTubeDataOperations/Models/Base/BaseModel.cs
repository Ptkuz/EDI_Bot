using Gurrex.Common.Helpers;
using Gurrex.Common.Interfaces;
using System.Reflection;
using YouTubeVideoDownloader.Interfaces.Models.Base;

namespace YouTubeVideoDownloader.YouTubeDataOperations.Models.Base
{
    /// <summary>
    /// Базовая модель
    /// </summary>
    public class BaseModel : IBaseModel, IResources
    {

        /// <summary>
        /// Сборка
        /// </summary>
        public Assembly Assembly => StaticHelpers.GetAssemblyInfo().Assembly;

        /// <summary>
        /// Имя сборки
        /// </summary>
        public AssemblyName? AssemblyName => StaticHelpers.GetAssemblyInfo().AssemblyName;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public virtual string ResourcesPath 
        {
            get => $"{AssemblyName?.Name}.Resources.Base.BaseModel";
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
