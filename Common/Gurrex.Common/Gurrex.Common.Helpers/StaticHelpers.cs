using Gurrex.Common.Helpers.Models;
using Gurrex.Common.Validations;
using System.Reflection;

namespace Gurrex.Common.Helpers
{
    /// <summary>
    /// Хелперы
    /// </summary>
    public static class StaticHelpers
    {
        /// <summary>
        /// Получить полную информацию о сборке
        /// </summary>
        /// <returns>Объект <see cref="AssemblyInfo"/> с информацией о сборке</returns>
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
