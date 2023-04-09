using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Interfaces
{
    /// <summary>
    /// Информация о сборке
    /// </summary>
    public interface IAssemblyInfo
    {
        /// <summary>
        /// Сборка
        /// </summary>
        Assembly Assembly { get; protected set; }

        /// <summary>
        /// Полное имя сборки
        /// </summary>
        AssemblyName FullAssemblyName { get; protected set; }

        /// <summary>
        /// Имя сборки
        /// </summary>
        string? AssemblyName { get; protected set; }

        /// <summary>
        /// Получить путь до ресурсов
        /// </summary>
        /// <param name="callBase">Вызывать ли базовую реализацию</param>
        /// <returns>Путь до ресурсов</returns>
        string GetResourcesPath(bool callBase = false);
    }
}
