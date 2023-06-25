using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Web.SignalR.Models
{
    /// <summary>
    /// Модель сообщения в точку SignalR
    /// </summary>
    public class SignalRMessageModel
    {
        /// <summary>
        /// Название соединения с хабом
        /// </summary>
        public string HubConnection { get; set; } = null!;

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; } = null!;
    }
}
