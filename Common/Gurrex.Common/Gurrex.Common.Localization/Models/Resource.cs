using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Localization.Models
{
    /// <summary>
    /// Ресурс
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Путь до файла ресурсов
        /// </summary>
        public string FileResourceName { get; set; } = null!;

        /// <summary>
        /// Имя ресурса
        /// </summary>
        public string ResourceName { get; set; } = null!;


        /// <summary>
        /// Вызывающая сборка
        /// </summary>
        public Assembly Assembly { get; set; } = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="fileResourceName">Путь до файла ресурсов</param>
        /// <param name="resourceName">Имя ресурса</param>
        /// <param name="assembly">Вызывающая сборка</param>
        public Resource(string fileResourceName, string resourceName, Assembly assembly)
        {
            FileResourceName = fileResourceName;
            ResourceName = resourceName;
            Assembly = assembly;
        }
    }
}
