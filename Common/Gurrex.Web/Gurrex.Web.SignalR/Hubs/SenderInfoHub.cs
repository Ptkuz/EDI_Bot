using Gurrex.Web.SignalR.Hubs.Base;
using Gurrex.Web.SignalR.Hubs;
using Gurrex.Web.Interfaces.SignalR;
using Microsoft.AspNetCore.SignalR;
using Gurrex.Common.Validations;

namespace Gurrex.Web.SignalR.Hubs
{
    public class SenderInfoHub : SenderInfo, ISenderInfoHub<SenderInfoHub>
    {
        public async Task ContextSendInfoAllClientsAsync(IHubContext<SenderInfoHub> hubContext, string methodName, CancellationToken cancel, params object[] arguments)
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

        public async Task ContextSendInfoByIdAsync(IHubContext<SenderInfoHub> hubContext, string methodName, string userId, CancellationToken cancel, params object[] arguments)
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

        public IClientProxy ContextGetUserById(IHubContext<SenderInfoHub> hubContext, string userId)
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
