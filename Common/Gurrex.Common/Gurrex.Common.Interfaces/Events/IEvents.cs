using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Common.Interfaces.Events
{
    /// <summary>
    /// Прогресс
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEvents<T> where T : EventArgs
    {
        /// <summary>
        /// Делегат события
        /// </summary>
        /// <param name="sender">Источник</param>
        /// <param name="e">Модель события</param>
        delegate Task ProcessHandler(object sender, T e, CancellationToken cancel);

        /// <summary>
        /// Событие изменения прогресса
        /// </summary>
        event ProcessHandler OutputDataChanged;
    }
}
