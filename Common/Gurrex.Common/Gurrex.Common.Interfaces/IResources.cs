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
    public interface IResources
    {
        /// <summary>
        /// Тип, вызывающий свойстов <see cref="ResourcesPath"/>
        /// </summary>
        string? TypeName { get; set; }

        /// <summary>
        ///// Путь до ресурсов
        /// </summary>
        string ResourcesPath { get; }
    }
}
