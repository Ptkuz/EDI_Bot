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
    public interface IAssembly<T> where T : class
    {
        /// <summary>
        /// Информация о сборке
        /// </summary>
        T AssemblyInfo { get; }
    }
}
