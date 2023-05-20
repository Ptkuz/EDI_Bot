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
    public interface IAssembly
    {
        /// <summary>
        /// Сборка
        /// </summary>
        Assembly Assembly { get; }

        /// <summary>
        /// Имя сборки
        /// </summary>
        AssemblyName AssemblyName { get; }
    }
}
