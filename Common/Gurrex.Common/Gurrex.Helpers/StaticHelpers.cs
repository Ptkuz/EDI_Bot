using Gurrex.Common.Validations;
using Gurrex.Helpers.Models;
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
        /// Получить полную информацию о сборке
        /// </summary>
        /// <returns></returns>
        public static AssemblyInfo GetAssemblyInfo() 
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            AssemblyName assemblyName = assembly.GetName();
            assembly.CheckObjectForNull(nameof(assemblyName));

            AssemblyInfo assemblyInfo = new AssemblyInfo(assembly, assemblyName);

            return assemblyInfo;
        }
    }
}
