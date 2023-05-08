using Gurrex.Common.Helpers.Models;
using Gurrex.Common.Validations;
using System.Diagnostics;
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

        /// <summary>
        /// Закрытие процесса со всеми подпроцессами
        /// </summary>
        /// <param name="processName">Имя процесса</param>
        public static async Task CloseProcessesWindows(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes != null)
            {
                foreach (var process in processes)
                {
                    process.Kill(true);
                    await process.WaitForExitAsync();
                }
            }
        }

        /// <summary>
        /// Закрыть подпроцессы процесса Windows
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static async Task CloseSubprocessesWindows(string processName) 
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(processName);
                foreach (Process process in processes)
                {
                    IList<Process> childsProcess = process.GetChildProcessesFromWindows();
                    childsProcess.CheckObjectForNull(nameof(childsProcess));

                    foreach (var child in childsProcess) 
                    {
                        child.Kill(true);
                        await child.WaitForExitAsync();
                    }
                }
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
