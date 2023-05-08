using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Web.Interfaces.SignalR
{
    /// <summary>
    /// Асинхронная работа с SignalR хабом
    /// </summary>
    /// <typeparam name="T">Класс хаба, ответственный за отправку сообщений</typeparam>
    public interface ISenderInfoHubAsync<T> where T : Hub
    {
        Task ContextSendInfoAllClientsAsync(IHubContext<T> hubContext, string methodName, CancellationToken cancel, params object[] arguments);

        Task ContextSendInfoByIdAsync(IHubContext<T> hubContext, string methodName, string userId, CancellationToken cancel, params object[] arguments);

        IClientProxy ContextGetUserById(IHubContext<T> hubContext, string userId);
    }
}
