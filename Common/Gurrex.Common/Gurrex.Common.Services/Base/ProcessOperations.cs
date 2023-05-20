using Gurrex.Common.Helpers;
using Gurrex.Common.Interfaces.Events;
using Gurrex.Common.Services.Models;
using Gurrex.Common.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Services.Base
{
    /// <summary>
    /// Работа с внешними процессами
    /// </summary>
    public class ProcessOperations
    {
        /// <summary>
        /// Текущие данные
        /// </summary>
        protected string? currentData;

        /// <summary>
        /// Асинхронно запустить внешний процесс
        /// </summary>
        /// <param name="processModel">Модель процесса</param>
        protected async Task StartProcessAsync(ProcessModel processModel) 
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.WorkingDirectory = processModel.Directory;
                processStartInfo.FileName = processModel.ProcessName;
                processStartInfo.Arguments = processModel.CmdCommand;
                processStartInfo.UseShellExecute = processModel.IsShellExecute;
                processStartInfo.CreateNoWindow = processModel.IsWindow;
                processStartInfo.RedirectStandardError = processModel.IsWindow;
                processStartInfo.RedirectStandardOutput = processModel.IsWindow;

                using Process? process = Process.Start(processStartInfo);

                process.CheckObjectForNull(nameof(process));

                if (processModel.IsWindow)
                {
                    SubscribeEvents(process);
                }

                await process.WaitForExitAsync(processModel.Cancel);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            finally 
            {
                await StaticHelpers.CloseSubprocessesWindows(processModel.AssemblyName);
            }
        }

        /// <summary>
        /// Подписаться на события получения данных
        /// </summary>
        /// <param name="process">Внешний процесс</param>
        private void SubscribeEvents(Process process) 
        {
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            process.ErrorDataReceived += HandleError;
            process.OutputDataReceived += HandleOutput;
            
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <param name="sender">Источник</param>
        /// <param name="e">Событие</param>
        protected virtual void HandleOutput(object sender, DataReceivedEventArgs e) 
        {
            string? data = e.Data;

            if (data == currentData) 
            {
                return;
            }
            currentData = data; 
        }

        /// <summary>
        /// Получить ошибки
        /// </summary>
        /// <param name="sender">Источник</param>
        /// <param name="e">Событие</param>
        protected virtual void HandleError(object sender, DataReceivedEventArgs e) 
        {
            string? data = e.Data;

            if (data == currentData) 
            {
                return;
            }
            currentData = data;
        }
    }
}
