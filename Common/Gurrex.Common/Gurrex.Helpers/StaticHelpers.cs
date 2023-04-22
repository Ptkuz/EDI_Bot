using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Helpers
{
    /// <summary>
    /// Хелперы
    /// </summary>
    public static class StaticHelpers
    {
        /// <summary>
        /// Получение сборки вызываемого метода
        /// </summary>
        /// <returns></returns>
        public static Assembly GetAssembly() 
        { 
            return Assembly.GetCallingAssembly(); 
        }

        /// <summary>
        /// Получение имени сборки
        /// </summary>
        /// <returns></returns>
        public static AssemblyName GetAssemblyName() 
        {
            Assembly assembly = GetAssembly();
            AssemblyName assemblyName = assembly.GetName();
            return assemblyName;
        }
    }
}
