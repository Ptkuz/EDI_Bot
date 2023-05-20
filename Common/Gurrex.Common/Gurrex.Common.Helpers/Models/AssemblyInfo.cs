﻿using System.Reflection;

namespace Gurrex.Common.Helpers.Models
{
    /// <summary>
    /// Вся информация о сборке
    /// </summary>
    public class AssemblyInfo
    {
        /// <summary>
        /// Экземпляр сборки
        /// </summary>
        public Assembly Assembly { get; set; } = null!;

        /// <summary>
        /// Полное имя сборки
        /// </summary>
        public AssemblyName AssemblyName { get; set; } = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="assembly">Экземпляр сборки</param>
        /// <param name="assemblyName">Полное имя сборки</param>
        public AssemblyInfo(Assembly assembly, AssemblyName assemblyName)
        {
            Assembly = assembly;
            AssemblyName = assemblyName;
        }
    }
}