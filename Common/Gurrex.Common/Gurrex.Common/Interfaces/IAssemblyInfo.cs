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
        /// Путь до файлов ресурсов
        /// </summary>
        string ResourcesPath { get; protected set; }
    }
}
