using Gurrex.Web.Interfaces.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeVideoDownloader.Interfaces.Services.Base
{
    /// <summary>
    /// Базовая модель 
    /// </summary>
    public interface IHub<T> where T : Hub
    {
        /// <summary>
        /// Хаб для передачи статусов клиенту
        /// </summary>
        ISenderInfoHubAsync<T> SenderInfoHubAsync { get; set; }

        /// <summary>
        /// Контекст хаба
        /// </summary>
        IHubContext<T> HubContext { get; set; }
    }
}
