using Gurrex.Common.Helpers;
using Gurrex.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace YouTubeVideoDownloader.WebApi.Controllers.Base
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    public class MainController : ControllerBase, IResources
    {

        /// <summary>
        /// Сборка
        /// </summary>
        public Assembly Assembly => StaticHelpers.GetAssemblyInfo().Assembly;

        /// <summary>
        /// Имя сборки
        /// </summary>
        public AssemblyName AssemblyName => StaticHelpers.GetAssemblyInfo().AssemblyName;

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public virtual string ResourcesPath { get; } = null!;

    }
}
