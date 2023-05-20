using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Services.Models
{
    /// <summary>
    /// Модель для параметров ProcessOperations
    /// </summary>
    public class ProcessModel
    {
        /// <summary>
        /// Имя процесса
        /// </summary>
        public string ProcessName { get; set; } = null!;

        /// <summary>
        /// Имя сборки, откуда происходит запуск процесса
        /// </summary>
        public string? AssemblyName { get; set; } = null!;

        /// <summary>
        /// Директория, откуда происходит запуск
        /// </summary>
        public string Directory { get; set; } = null!;

        /// <summary>
        /// Консольная команда
        /// </summary>
        public string CmdCommand { get; set; } = null!;

        /// <summary>
        /// Использовать ли Shell
        /// </summary>
        public bool IsShellExecute { get; set; }

        /// <summary>
        /// Запускать ли окно
        /// </summary>
        public bool IsWindow { get; set; }

        /// <summary>
        /// Токен отмены
        /// </summary>
        public CancellationToken Cancel { get; set; }


        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="processName">Имя процесса</param>
        /// <param name="assemblyName">Имя сборки, откуда происходит запуск процесса</param>
        /// <param name="directory">Директория, откуда происходит запуск</param>
        /// <param name="cmdCommand">Консольная команда</param>
        /// <param name="isWindow">Запускать ли окно</param>
        public ProcessModel(string processName, string? assemblyName, string directory, string cmdCommand, bool isShellExecute, bool isWindow) 
        {
            ProcessName = processName;
            AssemblyName = assemblyName;
            Directory = directory;
            CmdCommand = cmdCommand;
            IsShellExecute = isShellExecute;
            IsWindow = isWindow;
        }

        /// <summary>
        /// Асинхронный конструктор инициализатор
        /// </summary>
        /// <param name="processName">Имя процесса</param>
        /// <param name="assemblyName">Имя сборки, откуда происходит запуск процесса</param>
        /// <param name="directory">Директория, откуда происходит запуск</param>
        /// <param name="cmdCommand">Консольная команда</param>
        /// <param name="isWindow">Запускать ли окно</param>
        /// <param name="cancel">Токен отмены</param>
        public ProcessModel(string processName, string assemblyName, string directory, string cmdCommand, bool isShellExecute, bool isWindow, CancellationToken cancel) 
            : this(processName, assemblyName, directory, cmdCommand, isShellExecute, isWindow)
        {
            Cancel = cancel;
        }
    }
}
