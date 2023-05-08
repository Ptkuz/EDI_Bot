using Gurrex.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace YouTubeVideoDownloader.WebApi.Controllers.Base
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    public class MainController : ControllerBase, IResources
    {

        /// <summary>
        /// Тип, который вызывает <see cref="ResourcesPath"/>
        /// </summary>
        public virtual string? TypeName { get; set; } = nameof(MainController);

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public virtual string ResourcesPath { get; } = null!;
    }
}
