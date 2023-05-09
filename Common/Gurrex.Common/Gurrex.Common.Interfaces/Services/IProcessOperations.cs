using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Interfaces.Services
{
    /// <summary>
    /// Прогресс
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProcessOperations<T> where T : EventArgs
    {
        /// <summary>
        /// Делегат события
        /// </summary>
        /// <param name="sender">Источник</param>
        /// <param name="e">Модель события</param>
        delegate void ProcessHandler(object sender, T e);

        /// <summary>
        /// Событие изменения прогресса
        /// </summary>
        event ProcessHandler OutputDataChanged;
    }
}
