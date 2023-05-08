using Gurrex.Common.Validations;
using Gurrex.Web.Interfaces.SignalR;
using Gurrex.Web.SignalR.Hubs.Base;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurrex.Web.SignalR.Hubs.Async
{
    public class SenderInfoHubAsync : SenderInfo, ISenderInfoHubAsync<SenderInfoHubAsync>
    {
        public async Task ContextSendInfoAllClientsAsync(IHubContext<SenderInfoHubAsync> hubContext, string methodName, CancellationToken cancel, params object[] arguments)
        {
            try
            {
                methodName.CheckStringForNullOrWhiteSpace();

                foreach (var argument in arguments)
                {
                    await hubContext.Clients.All.SendAsync(methodName, argument, cancel);
                }
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public async Task ContextSendInfoByIdAsync(IHubContext<SenderInfoHubAsync> hubContext, string methodName, string userId, CancellationToken cancel, params object[] arguments)
        {
            try
            {
                methodName.CheckStringForNullOrWhiteSpace();
                userId.CheckStringForNullOrWhiteSpace();

                foreach (var argument in arguments)
                {
                    await hubContext.Clients.User(userId).SendAsync(methodName, argument, cancel);
                }
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public IClientProxy ContextGetUserById(IHubContext<SenderInfoHubAsync> hubContext, string userId)
        {
            try
            {
                userId.CheckStringForNullOrWhiteSpace();
                IClientProxy clientProxy = hubContext.Clients.User(userId);
                return clientProxy;
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
