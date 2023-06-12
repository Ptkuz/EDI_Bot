using Gurrex.Common.Helpers;
using Gurrex.Common.Helpers.Models;
using Gurrex.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace YouTubeVideoDownloader.WebApi.Controllers.Base
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    public class MainController : ControllerBase, IResources<AssemblyInfo>
    {

        /// <summary>
        /// Сборка
        /// </summary>
        public AssemblyInfo AssemblyInfo => StaticHelpers.GetAssemblyInfo();

        /// <summary>
        /// Путь до ресурсов
        /// </summary>
        public virtual string ResourcesPath { get; } = null!;

    }
}
