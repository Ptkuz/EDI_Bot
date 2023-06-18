using System.Reflection;

namespace Gurrex.Common.Localization.Models
{
    /// <summary>
    /// Ресурс
    /// </summary>
    public class Resource
    {

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
        /// <param name="resourceName">Имя ресурса</param>
        /// <param name="assembly">Вызывающая сборка</param>
        public Resource(string resourceName, Assembly assembly)
        {
            ResourceName = resourceName;
            Assembly = assembly;
        }
    }
}
